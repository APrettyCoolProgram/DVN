❰ [DVN](../../README.md) ❬ [Release notes](./README.md) ❬ Version 2.0

<div align="center">

  <img src="../../.github/logo/dvn-Logo-384x184.png" alt="DVN">

  <h2>Version 2.0 Release notes</h2>

</div>

| CONTENTS                              |
|:--------------------------------------|
| [Summary](#summary)                   |
| [New features](#new-features)         |
| [Breaking changes](#breaking-changes) |
| [Bug fixes](#bug-fixes)               |
| [Known issues](#known-issues)         |
| [Other changes](#other-changes)       |
| [Miscellaneous](#miscellaneous)       |

***

# Summary

* Release date: 2026-9-17
* [Download](https://github.com/APrettyCoolProgram/DVN/releases/tag/v1.3)
* [Manual](https://github.com/APrettyCoolProgram/DVN/tree/1.3/docs/man)

**DVN** 2.0 is a major update that focuses on simplifying the framework and integrating basic Scoop.sh functionality.

# New features

* Scoop.sh   
  Basic integration with [Scoop](https://scoop.sh/) for easier installation and management of DVN.

* Display version number is displayed when DVN is executed  

# Breaking changes

**DVN** 2.0 is not compatible with **DVN** 1.x.

# Bug fixes

None.

# Known issues

None.

# Miscellaneous


* Variables:

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


## Added
**ADDED** `Ns:dvn.Core.Resources`  
**ADDED** Ns:dvn.Core.Resources  
**[  ADDED]** Ns:dvn.Core.CommandLine  
**[CHANGED]** dvn.Blueprint.Catalog.cs -> dvn.Core.Resources.Catalog.cs  
**CHANGED** dvn.Blueprint.UserMessage.cs -> dvn.Core.Resources.UsrMsg.cs  
**CHANGED** dvn.Core.Arguments.cs -> dvn.Core.CommandLine.Arguments.cs  
**CHANGED** AppConfig.LoadFromLocalFile() -> AppConfig.Load()  
**CHANGED** The `lst_` prefix -> `Lst` in dvn.Core.Resources.UsrMsg.cs  
**CHANGED** The `msg_` prefix -> `Msg` in dvn.Core.Resources.UsrMsg.cs  
**CHANGED** Text formatting in dvn.Core.Resources.UsrMsg.cs  


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

❰ [DVN](../../README.md) ❬ [Release notes](./README.md) ❬ Version 2.0
