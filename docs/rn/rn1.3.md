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
| [Miscellaneous](#miscellaneous)       |

***

# Summary

* Release date: June 6, 2024
* [Download](https://github.com/APrettyCoolProgram/DVN/releases/tag/v1.3)
* [Manual](https://github.com/APrettyCoolProgram/DVN/tree/1.3/docs/man)

**DVN** 2.0 is a major update that focuses on simplifying the framework and integrating basic Scoop.sh functionality.

# New features

* **Scoop.sh**  
  Basic integration with [Scoop](https://scoop.sh/) for easier installation and management of DVN.

# Breaking changes

**DVN** 2.0 is not compatible with **DVN** 1.x.

# Bug fixes

None.

# Known issues

None.

# Miscellaneous

## Changes from the **DVN** 1.x codebase



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


**`FIXED`**  

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
