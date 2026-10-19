# DVN Source Code Flow

This page gives a high-level view of how the DVN codebase currently moves from startup to command handling, configuration, and the supporting utility layers.

## 1) Overall application flow

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
	P -- list --> S[Environment listing hook]
	P -- other --> T[Environment launch/create hook]

	Q --> E
	R --> E
	S --> E
	T --> E
```

## 2) Startup and session setup

```mermaid
flowchart TD
	A[Program.cs] --> B[AppState.Start(string[])]
	B --> C[Clear console]
	C --> D[Print startup banner]
	D --> E{Any command-line arguments?}
	E -- No --> F[Stop with "Missing arguments"]
	E -- Yes --> G[AppState.NewSession]

	G --> H[AppConfiguration.Load('.\\dvn.config')]
	H --> I{Config file found?}
	I -- No --> J[Build default config]
	J --> K[DuJson.ExportLocalFile<AppConfiguration>]
	K --> L[DuJson.ImportLocalFile<AppConfiguration>]
	I -- Yes --> L

	L --> M{ScoopEnabled?}
	M -- Yes --> N[AppExtension.Scoop]
	M -- No --> O[Continue]
	N --> O
	O --> P[AppArgument.GetComponents]
	P --> Q[AppArgument.Parse]
```

## 3) Command routing

```mermaid
flowchart TD
	A[AppArgument.Parse] --> B{Command value}

	B -- about --> C[UsrMsg.MsgAbout]
	B -- help --> D[UsrMsg.MsgHelp]
	B -- list --> E[Environment list path]
	B -- other --> F[Manifest / environment path]

	C --> G[Console.WriteLine]
	D --> G
	E --> H[Currently stubbed in code]
	F --> H
```

## 4) Configuration and resource flow

```mermaid
flowchart LR
	A[Catalog] --> B[Default ignored files]
	A --> C[Default ignored folders]
	B --> D[AppConfiguration.ExcludedFiles]
	C --> E[AppConfiguration.ExcludedFolders]

	F[AppConfiguration.Load] --> G[DuJson.ImportLocalFile]
	F --> H[Create config if missing]
	H --> I[UsrMsg.MsgCreateConfig]
```

## 5) Manifest and environment flow

```mermaid
flowchart TD
	A[DvnEnvironment.GetAvailable] --> B[Scan .\\manifest for *.dvn files]
	B --> C[Build environment name/description map]
	C --> D[Return Dictionary<string, string>]

	E[_DvnEnvironment.DisplayAvailable] --> F{Any environments?}
	F -- No --> G[Stop with "No environments found"]
	F -- Yes --> H[Format list output]
	H --> I[Print environment list]

	J[_DvnEnvironment.LoadFromManifest] --> K[Currently commented / placeholder]
	K --> L[Future: load manifest and launch environment]
```

## 6) Manifest runtime actions

```mermaid
flowchart TD
	A[_DvnManifest] --> B[DevelopmentEnvironment]
	A --> C[EnvironmentApplications]
	A --> D[WebBrowser]

	B --> E[Backup settings]
	B --> F[Source directories]
	B --> G[Backup destination]

	C --> H[_DvnApplication.StartApplications]
	H --> I[Start each app via Process]

	D --> J[_DvnWebBrowser.OpenPages]
	J --> K[Open pages with browser-specific commands]
```

## 7) Backup flow

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

	E --> J[Exclude files and folders from copy]
```

## 8) Utility layer

```mermaid
flowchart LR
	A[DuJson] --> B[Read/write JSON files]
	C[DuDirectory] --> D[Create/reset/copy directories]
	E[DuCmdExe] --> F[Run cmd.exe commands]

	F --> G[AppExtension.Scoop]
	G --> H[scoop update *]
```

## Notes

- Several environment and manifest execution paths are still partially stubbed in the current source.
- The diagrams above show both implemented behavior and the intended flow where the code contains placeholders.
- If you want, this page can be expanded later into a more detailed architecture map or sequence diagram.
