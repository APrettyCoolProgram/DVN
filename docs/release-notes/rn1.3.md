❰ [DVN](../../README.md) ❬ [Release notes](./README.md) ❬ Version 1.3

<div align="center">

  <img src="../../.github/logo/dvn-Logo-384x184.png" alt="DVN">

  <h2>Version 1.3 Release notes</h2>

</div>

| CONTENTS                                  |
|:------------------------------------------|
| [About this release](#about-this-release) |
| [Known Issues](#known-issues)             |
| [Miscellaneous](#miscellaneous)           |

***

# About this release

This release focuses on:

* Basic Scoop integration
* Quality of life additions
* Code refactors
* .NET framework upgrade

[Download DVN 1.3](https://github.com/APrettyCoolProgram/DVN/releases/tag/v1.3)  
[DVN 1.3 manual](https://github.com/APrettyCoolProgram/DVN/tree/1.3/docs/man)

## Added

* **Scoop integration**  
  What this is.

* **Version number is now displayed**  
  The version number is now displayed when running **DVN**.

* **`Ns:dvn.Core.Resources`**  
  This is the standard location for blueprints, catalogs, etc.

## Changed

* Updated `Du.DuJson.cs` from `b250801` to `b260909`

* Cleaned up the text formatting in `dvn.Core.Resources.UsrMsg.cs`

* Classes:
  * `dvn.Blueprint.Catalog.cs` -> `dvn.Core.Resources.Catalog.cs`
  * `dvn.Blueprint.UserMessage.cs` -> `dvn.Core.Resources.UsrMsg.cs`

* Methods:
  * `AppConfig.LoadFromLocalFile()` -> `AppConfig.Load()`

* Variables:
  * `lst_` to `Lst` in `dvn.Core.Resources.UsrMsg.cs`
  * `msg_` to `Msg` in `dvn.Core.Resources.UsrMsg.cs`

## Fixed

None.

## Removed

* **`Ns:dvn.Blueprint`**  
  This is the standard location for blueprints, catalogs, etc.

* **Simplified the DVN framework**  
  I've decided that I want DVN to focus on just managing environments, not handling other tasks, so I've removed the `.dvn/` framework structure. Now DVN just consists of the following two files:
  * `dvn.exe`
  * `dvn.config`

# Known issues

None.

# Miscellaneous

* Renamed release notes to `rnX.y.md`
* Changed the release from `RYY.MM` to `VX.y` format.
* Updated from target framework from .NET 9 to .NET 10
* XML documentation updates

<br/>

***

❰ [DVN](../../README.md) ❬ [Release notes](./README.md) ❬ Version 1.3
