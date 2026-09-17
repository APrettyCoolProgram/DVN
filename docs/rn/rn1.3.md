❰ [DVN](../../README.md) ❬ [Release notes](./README.md) ❬ Version 1.3

<div align="center">

  <img src="../../.github/logo/dvn-Logo-384x184.png" alt="DVN">

  <h2>Version 1.3 Release notes</h2>

</div>

| CONTENTS                                  |
|:------------------------------------------|
| [Summary](#summary) |
| [New features](#new-features)             |
| [Bug fixes](#bug-fixes) |
| [Known issues](#known-issues) |
| [Miscellaneous](#miscellaneous)           |

***

# Summary

* Release date: June 6, 2024
* [Download](https://github.com/APrettyCoolProgram/DVN/releases/tag/v1.3)
* [Manual](https://github.com/APrettyCoolProgram/DVN/tree/1.3/docs/man)

This release focuses on:

* Basic Scoop integration
* Quality of life additions
* Code refactors
* .NET framework upgrade

# New features

## Scoop integration

What this is.

# Bug fixes

# Known issues

None.

# Changes

* `dvn.Blueprint.Catalog.cs` -> `dvn.Core.Resources.Catalog.cs`
* `dvn.Blueprint.UserMessage.cs` -> `dvn.Core.Resources.UsrMsg.cs`
* `dvn.Core.Arguments.cs` -> `dvn.Core.CommandLine.Arguments.cs`

* Methods:
* `AppConfig.LoadFromLocalFile()` -> `AppConfig.Load()`

* Variables:
* `lst_` to `Lst` in `dvn.Core.Resources.UsrMsg.cs`
* `msg_` to `Msg` in `dvn.Core.Resources.UsrMsg.cs`

# Fixed

None.

# Removed

## **`.dvn/`**

I've decided that I want DVN to focus on just managing environments, not handling other tasks, so I've removed the `.dvn/` framework structure. Now DVN just consists of the following two files:
* `dvn.exe`
* `dvn.config`

**`dvn.Core.Framework.cs`**  
  This file has been removed as part of the simplification of the DVN framework.

* **`list` command**  
  DVN now stores environment information per-project, so the `list` command has been removed.

* **`REMOVED`**  `Ns:dvn.Blueprint`
* **`REMOVED`**  `dvn.Core.Framework.cs`

# Known issues

None.

# Miscellaneous

**`ADDED`** Namespace: `dvn.Core.Resources`  
**`ADDED`** Namespace: `dvn.Core.CommandLine`  
**`ADDED`** Display version number when DVN is executed  
**`FIXED`**  
**`CHANGED`** Text formatting in `dvn.Core.Resources.UsrMsg.cs`
**`UPDATED`** Update from target framework from .NET 9 to .NET 10
**`UPDATED`** Update XML documentation
**`UPDATED`** `Du.DuJson.cs` from `b250801` to `b260909`
**`DEPRECIATED`**  
**`REMOVED`**  
**`SECURITY`**



# Repository

* Updated to the current release of [Repsitory-Template](https://github.com/APrettyCoolProgram/Repository-Template).

<br/>

***

❰ [DVN](../../README.md) ❬ [Release notes](./README.md) ❬ Version 1.3
