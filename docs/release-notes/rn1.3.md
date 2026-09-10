[❰ Back to DVN repository](../../README.md)

<div align="center">

  <img src="../../.github/logo/dvn-Logo-192x92.png" alt="DVN">

  <h2>Version 1.3 Release Notes</h2>

</div>

> [!NOTE]
> This release focuses on:
>
> * [Added basic support for Scoop](#scoop)
> * [Quality of life additions](#quality-of-life-additions)
> * [Updated .NET version](#updated-to-net-10)
> * [Code refactors](#code-refactors)
> * [Framework updates](#framework-updates)

***

# Scoop

# Quality of life additions

* Version number is now displayed

# Updated to .NET version

* Updated from .NET 9 to .NET 10

# Code refactors

* Added the `dvn.Core.Resources` namespace, which is the new standard location for blueprints, catalogs, etc.

* Moved the following files from `Ns:dvn.Blueprint` to `Ns:dvn.Core.Resources`:
  * `Catalog.cs`
  * `UserMessage.cs` (renamed to `UsrMsg.cs`)

* Changed the following method prefixes so they conform to the new naming conventions:
  * `lst_` to `Lst` in `dvn.Core.Resources.UsrMsg.cs`
  * `msg_` to `Msg` in `dvn.Core.Resources.UsrMsg.cs`

* Updated `Du.DuJson.cs` from `b250801` to `b260909`

# Framework updates

* Renamed release notes to `rnX.y.md`

# Misc

* Changed the release from `RYY.MM` to `VX.y` format.
* Cleaned up the text formatting in `dvn.Core.Resources.UsrMsg.cs`
* XML documentation updates.
  
<br/>

***

[❰ Back to DVN repository](../../README.md)