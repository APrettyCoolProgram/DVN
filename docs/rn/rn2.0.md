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

## Scoop.sh integration

**DVN** now has basic integration with [Scoop.sh](https://scoop.sh/).

For now, if the `ScoopEnabled` setting is enabled in the configuration, DVN will update scoop (`scoop update *`) when it runs.

## Framework simplification

I've decided that I want DVN to focus on just managing environments, not handling other tasks, so I've removed the `.dvn/` framework structure. Now DVN just consists of the following two files:

* `dvn.exe`
* `dvn.config`
* `manifest/`

## Configuration simplification

I've decided to simplify the configuration system by hardcoding the `ManifestPath` and `ManifestExtension`, since I can't really think of a reason these would need to be configurable.

## Miscellaneous

* Configuration file is created even if arguments are not passed
* Minor refactoring to improve code readability and maintainability
* Added `AppData/` folder
* Added `AppData/XMLDoc` folder for storing XML documentation files
* Added `AppData/XMLDoc/NsDoc.xml` file for storing XML documentation for namespaces

<br/>

***

❰ [DVN](../../README.md) ❬ [Release notes](./README.md) ❬ Version 2.0
