❰ [DVN](../../README.md) ❬ [Release notes](./README.md) ❬ Version 2.0

<div align="center">

  <img src="../../.github/logo/dvn-Logo-384x184.png" alt="DVN">

  <h2>Version 2.0 Release notes</h2>

Release date: 2026-10-DD  
[Download](https://github.com/APrettyCoolProgram/DVN/releases/tag/v2.0)  
[Manual](../man/README.md)

</div>

***

**DVN** 2.0 is a major update that focuses on simplifying the framework and integrating basic Scoop.sh functionality.

> [!IMPORTANT]
> **DVN 2.x** is not compatible with **DVN 1.x**.
>
> **DVN 2.0** will only work on Windows operating systems; MacOS/Linux support will return in a future update.

## Extension library framework

I've added a new `dvn.Extensions` namespace for organizing and managing extension methods and related functionality within the DVN framework.

### New extension: `ScoopSh`

**DVN** now has basic integration with [Scoop.sh](https://scoop.sh/), via the `dvn.Extensions.ScoopSh` extension.

Currently, the `ScoopSh` extension only supports updating Scoop when DVN runs.

## Framework simplification

I've decided that I want DVN to focus on just managing environments, not handling other tasks, so I've removed the `.dvn/` framework structure. Now DVN just consists of the following two files:

* `dvn.exe`
* `dvn.config`
* `manifest/`

The staging area for backups is now `./.staging`. This folder is removed automatically after the backup process is complete.

## Configuration simplification

I've decided to simplify the configuration system by hardcoding the `ManifestPath` and `ManifestExtension`, since I can't really think of a reason these would need to be configurable.

I've also removed the `LstOtherIgnoredFiles` and `LstOtherIgnoredFolders` settings from the configuration because I would need to use placeholders so they would be written to the configuration file. This would create unnecessary complexity, when the existing settings already cover most common use cases (and can be modified, if necessary).

# Namespace restructure

I've restructured the namespaces within the DVN framework to better organize the code and improve maintainability.

```text
dvn.Deven
dvn.Du
dvn.DvnApp
dvn.DvnApp.Resource
dvn.Extension
```

## Hardcoded values/resources

I've moved a number of values that were previously passed to methods or read from the configuration into hardcoded values within the code. For example, `AppConfiguration.Load()` now directly defines the configuration file path instead of having it passed (e.g., `AppConfiguration.Load("dvn.config")`).

Since these are file paths and other resources that are unlikely to change frequently, I think it makes more sense to have them defined as close where they are used as possible.

## Miscellaneous

* Migrated `Core.DvnWebBrowser.cs` to `Core.DvnManifest.cs` and `Core.DvnEnvironment.cs`
* Migrated code from `Core.DvnApplication.cs` to `Core.DvnManifest.cs` and `Core.DvnEnvironment.cs`
* Minor refactoring to improve code readability and maintainability
* Added `UsrMsg.ManifestNotFound()`
* Added `AppData/` folder
* Added `AppData/XMLDoc` folder for storing XML documentation files
* Added `AppData/XMLDoc/NsDoc.xml` file for storing XML documentation for namespaces

<br/>

***

❰ [DVN](../../README.md) ❬ [Release notes](./README.md) ❬ Version 2.0
