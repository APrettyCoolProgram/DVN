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

* Added basic support for Scoop
* Quality of life additions
* Updated .NET version
* Code refactors
* Framework updates

[Download DVN 1.3](https://github.com/APrettyCoolProgram/DVN/releases/tag/v1.3)

## Added

* Scoop integration

* Version number is now displayed

* Added the `dvn.Core.Resources` namespace, which is the new standard location for blueprints, catalogs, etc.

* Moved the following files from `Ns:dvn.Blueprint` to `Ns:dvn.Core.Resources`:
  * `Catalog.cs`
  * `UserMessage.cs` (renamed to `UsrMsg.cs`)

* Changed the following method prefixes so they conform to the new naming conventions:
  * `lst_` to `Lst` in `dvn.Core.Resources.UsrMsg.cs`
  * `msg_` to `Msg` in `dvn.Core.Resources.UsrMsg.cs`

* Updated `Du.DuJson.cs` from `b250801` to `b260909`

## Changed

None.

## Fixed

None.

## Removed

None.

# Known issues

None.

# Miscellaneous

* Renamed release notes to `rnX.y.md`
* Changed the release from `RYY.MM` to `VX.y` format.
* Cleaned up the text formatting in `dvn.Core.Resources.UsrMsg.cs`

* Updated from .NET 9 to .NET 10
* XML documentation updates

<br/>

***

❰ [DVN](../../README.md) ❬ [Release notes](./README.md) ❬ Version 1.3
