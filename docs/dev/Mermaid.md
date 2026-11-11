# DVN Project Flow

## CONTENTS

- [Project Structure](#project-structure) — components and their dependencies
- [Runtime Flow](#runtime-flow) — execution path from startup to exit

---

## Project Structure

This diagram shows the components of the single `dvn` console project (`dvn.csproj`) grouped by namespace, with their dependencies and external touchpoints.

```mermaid
flowchart TD
    Program[Program.Main]

    subgraph DvnApp[DvnApp - application core]
        FlightPath[FlightPath - startup and routing]
        TheState[TheState - runtime state]
        Args[Args - CLI argument parsing]
        Config[Config - dvn.config settings]
        subgraph Resource[DvnApp.Resource]
            Catalog[Catalog - default exclusion lists]
            UsrMsg[UsrMsg - user messages]
        end
    end

    subgraph Deven[Deven - environment handling]
        Manifest[Manifest - .deven manifest model]
        Launcher[Launcher - starts apps and pages]
        Archiver[Archiver - data backup]
        Details[Details - list environments]
        DevenApp2[DevenApp - application entry model]
    end

    subgraph Extension[Extension]
        ScoopSh[ScoopSh - Scoop.sh integration]
    end

    subgraph Du[Du - utility library]
        DuJson[DuJson - JSON import and export]
        DuDirectory[DuDirectory - directory copy and reset]
        DuDictionary[DuDictionary - dictionary formatting]
        DuCmdExe[DuCmdExe - run shell commands]
    end

    subgraph External[External systems]
        FileSystem[(Local files - dvn.config and .deven)]
        Processes[Windows processes - apps, browsers, cmd]
        Scoop[Scoop.sh package manager]
    end

    Program -->|SpinUp| FlightPath
    FlightPath -->|NewState| TheState
    FlightPath -->|routes commands to| Details
    FlightPath -->|Load and CreateEmpty| Manifest
    FlightPath -->|Launch| Launcher
    FlightPath -->|Roundhouse| ScoopSh
    FlightPath --> UsrMsg

    TheState --> Config
    TheState --> Args
    TheState --> Manifest

    Config -->|defaults from| Catalog
    Config -->|holds settings for| ScoopSh
    Config -->|read and write dvn.config| DuJson

    Manifest -->|read and write .deven| DuJson
    Manifest -->|contains| DevenApp2
    Manifest -->|SpinDown on missing file| FlightPath

    Launcher -->|ArchiveData| Archiver
    Launcher -->|starts| Processes
    Details -->|reads .deven files| DuJson
    Details --> DuDictionary

    Archiver -->|stage and copy| DuDirectory
    Archiver -->|writes zip archives| FileSystem

    ScoopSh -->|RunCommand| DuCmdExe
    DuCmdExe --> Scoop
    DuJson --> FileSystem
```

**Notes:**
- There is a deliberate circular reference between `Manifest` and `FlightPath`: `Manifest.Load` calls `FlightPath.SpinDown` when a manifest file is missing.
- `UsrMsg` edges are shown only from `FlightPath` for readability; most classes also write user messages via `UsrMsg` or direct `Console.WriteLine` calls (several marked `TODO - UsrMsg`).

---

## Runtime Flow

This diagram traces execution from `Program.Main` through `FlightPath.SpinUp` and `Roundhouse`, including command routing and the environment-launch path.

```mermaid
flowchart TD
    Start([dvn starts]) --> SpinUp[FlightPath.SpinUp - clear console, show startup message]
    SpinUp --> HasArgs{Arguments provided?}
    HasArgs -->|No| ExitNoArgs[SpinDown - show missing-args message and exit]
    HasArgs -->|Yes| NewState[TheState.NewState]

    NewState --> LoadConfig[Config.Load]
    LoadConfig --> ConfigExists{dvn.config exists?}
    ConfigExists -->|No| BuildConfig[Config.Build - create default dvn.config]
    ConfigExists -->|Yes| ImportConfig[DuJson import dvn.config]
    BuildConfig --> ImportConfig
    ImportConfig --> ParseArgs[Args.GetComponents - parse command and options]
    ParseArgs --> Roundhouse{FlightPath.Roundhouse - which command?}

    Roundhouse -->|about| About[Show about message] --> End([Done])
    Roundhouse -->|help| Help[Show help message] --> End
    Roundhouse -->|list| ListEnvs[Details.DisplayDetails - read all .deven files]
    ListEnvs --> AnyEnvs{Environments found?}
    AnyEnvs -->|No| ExitNoEnvs[SpinDown - no environments found]
    AnyEnvs -->|Yes| ShowEnvs[Show environment names and descriptions] --> End

    Roundhouse -->|new| NewManifest[Manifest.CreateEmpty - write new.deven]
    NewManifest --> ExitNew[SpinDown and exit]

    Roundhouse -->|anything else| ScoopEnabled{ScoopSh enabled in config?}
    ScoopEnabled -->|Yes| ScoopUpdate{ScoopSh update enabled?}
    ScoopUpdate -->|Yes| RunScoop[Run scoop update via DuCmdExe]
    ScoopUpdate -->|No| LoadManifest[Manifest.Load command.deven]
    RunScoop --> LoadManifest
    ScoopEnabled -->|No| LoadManifest

    LoadManifest --> ManifestExists{Manifest file exists?}
    ManifestExists -->|No| ExitNoManifest[SpinDown - manifest not found]
    ManifestExists -->|Yes| Launch[Launcher.Launch]

    Launch --> ArchiveCheck{Archive enabled in manifest or -b option?}
    ArchiveCheck -->|Yes| Archive[Archiver - copy sources to staging, zip to target]
    ArchiveCheck -->|No| SkipArchive[Show archive-disabled message]
    Archive --> StartApps[Launcher.StartApplications - start each manifest app]
    SkipArchive --> StartApps
    StartApps --> OpenPages[Launcher.OpenPages - open manifest webpages per browser]
    OpenPages --> ExitLaunch[SpinDown - show exit message]
```

**Notes:**
- Any command other than `about`, `help`, `list`, or `new` is treated as an environment name — DVN loads `.\<command>.deven` (`FlightPath.Roundhouse`).
- Archiving is enabled when either the manifest's `ArchiveEnabled` flag is `true` or the `-b` option is passed (`Archiver.IsArchiveEnabled`).
- `Launcher.OpenPages` assumes `Manifest.Webpages` is non-null; a manifest without a `Webpages` section would throw at this point — this is shown as the happy path only.
- Application launching uses `Process.Start` and is Windows-only per the remarks in `Launcher.StartApplications`.

Both diagrams were validated for Mermaid syntax. No code or project files were changed.