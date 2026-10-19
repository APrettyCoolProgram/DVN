# DVN Project Flow

This page documents the current DVN codebase flow with Mermaid diagrams only.
The diagrams are grounded in the present source tree and the runtime paths that are
implemented today.

Relevant source files:

- `src/Program.cs`
- `src/Core/AppState.cs`
- `src/Core/AppArgument.cs`
- `src/Core/AppConfiguration.cs`
- `src/Core/DvnEnvironment.cs`
- `src/Core/Manifest/_DvnManifest.cs`
- `src/Core/Manifest/_DvnApplication.cs`
- `src/Core/Manifest/_DvnWebBrowser.cs`
- `src/Archiver/BackupData.cs`
- `src/Du/DuJson.cs`
- `src/Du/DuDirectory.cs`
- `src/Du/DuCmdExe.cs`

## Contents

- [Runtime flow](#runtime-flow)
- [Command handling](#command-handling)
- [Configuration and defaults](#configuration-and-defaults)
- [Environment and manifest flow](#environment-and-manifest-flow)
- [Manifest runtime actions](#manifest-runtime-actions)
- [Backup flow](#backup-flow)
- [Utility layer](#utility-layer)
- [Notes](#notes)

## Runtime flow

```mermaid
flowchart TD
	A[Program.Main] --> B[AppState.Start]
	B --> C{Arguments provided?}
	C -- No --> D[Print missing-arguments message]
	D --> E[Exit]
	C -- Yes --> F[NewSession]

	F --> G[Load .\\dvn.config]
	G --> H{Config exists?}
	H -- No --> I[Create default config]
	I --> J[Print config-created message]
	H -- Yes --> K[Read config JSON]
	J --> K

	K --> L{ScoopEnabled?}
	L -- Yes --> M[Run scoop update *]
	L -- No --> N[Skip Scoop update]
	M --> O[Parse command-line arguments]
	N --> O

	O --> P{Command}
	P -- about --> Q[Print about message]
	P -- help --> R[Print help message]
	P -- list --> S[Stubbed environment listing path]
	P -- other --> T[Stubbed manifest / environment path]

	Q --> E
	R --> E
	S --> E
	T --> E
```

## Command handling

```mermaid
flowchart TD
	A[AppArgument.GetComponents] --> B[Command]
	A --> C[Options]

	B --> D{Command value}
	D -- about --> E[UsrMsg.MsgAbout]
	D -- help --> F[UsrMsg.MsgHelp]
	D -- list --> G[Environment list flow]
	D -- other --> H[Manifest launch flow]

	E --> I[Console.WriteLine]
	F --> I
	G --> J[Currently stubbed in code]
	H --> J
```

## Configuration and defaults

```mermaid
flowchart TD
	A[AppConfiguration.Load] --> B{dvn.config exists?}
	B -- No --> C[AppConfiguration.Build]
	C --> D[DuJson.ExportLocalFile<AppConfiguration>]
	D --> E[Print config-created message]
	B -- Yes --> F[DuJson.ImportLocalFile<AppConfiguration>]
	E --> F

	G[Catalog] --> H[Default ignored files]
	G --> I[Default ignored folders]
	H --> J[AppConfiguration.ExcludedFiles]
	I --> K[AppConfiguration.ExcludedFolders]
```

## Environment and manifest flow

```mermaid
flowchart TD
	A[DvnEnvironment.GetAvailable] --> B[Scan .\\manifest for *.dvn files]
	B --> C[Build environment name/description map]
	C --> D[Return Dictionary<string, string>]

	E[_DvnEnvironment.DisplayAvailable] --> F{Any environments?}
	F -- No --> G[Stop with "No environments found"]
	F -- Yes --> H[Format and print list]

	I[_DvnEnvironment.LoadFromManifest] --> J[Currently commented placeholder]
	J --> K[Future: load manifest and launch environment]
```

## Manifest runtime actions

```mermaid
flowchart TD
	A[_DvnManifest] --> B[DevelopmentEnvironment]
	A --> C[EnvironmentApplications]
	A --> D[WebBrowser]

	B --> E[BackupEnabled]
	B --> F[BackupSources]
	B --> G[BackupLocation]

	C --> H[_DvnApplication.StartApplications]
	H --> I[Start each app via Process]

	D --> J[_DvnWebBrowser.OpenPages]
	J --> K[Open pages with browser-specific commands]
```

## Backup flow

```mermaid
flowchart TD
	A[BackupData.IsBackupEnabled] --> B{Manifest backup enabled OR -b option?}
	B -- Yes --> C[Run backup pipeline]
	B -- No --> D[Skip backup]

	C --> E[BackupData.BackupFolders]
	E --> F[CopyToStaging]
	F --> G[DuDirectory.Reset staging folder]
	G --> H[DuDirectory.CopyExclude per source]
	H --> I[Create zip archive per staged folder]
```

## Utility layer

```mermaid
flowchart LR
	A[DuJson] --> B[Read/write JSON files]
	C[DuDirectory] --> D[Create/reset/copy directories]
	E[DuCmdExe] --> F[Run cmd.exe commands]

	F --> G[AppExtension.Scoop]
	G --> H[scoop update *]
```

## Notes

- Some environment and manifest execution paths are still placeholders in the current source.
- The diagrams describe confirmed code paths and avoid inventing behavior that is not yet implemented.
- This page is intended as a compact project-flow reference for DVN.
