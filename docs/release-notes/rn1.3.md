[❰ Back to DVN repository](../../README.md)

<div align="center">

  <img src="../../.github/logo/dvn-Logo-192x92.png" alt="DVN">

  <h2>Version 1.3 Release Notes</h2>

</div>

> [!NOTE]
> This release focuses on:
>
> * [Code refactors](#code-refactors)
> * [Added basic support for Scoop](#scoop)
> * [Framework updates](#framework-updates)

***

# Code refactors

* Added the `dvn.Core.Resources` namespace, which is the new standard location for blueprints, catalogs, etc.

* Moved the following files from `Ns:dvn.Blueprint` to `Ns:dvn.Core.Resources`:
  * `Catalog.cs`
  * `UserMessage.cs` (renamed to `UsrMsg.cs`)

* Changed the following method prefixes so they conform to the new naming conventions:
  * `lst_` to `Lst` in `dvn.Core.Resources.UsrMsg.cs`
  * `msg_` to `Msg` in `dvn.Core.Resources.UsrMsg.cs`

# Scoop

# Framework updates

* Renamed release notes to `rnX.y.md`

# Misc

* Updated to .NET 10
* Changed the release from RYY.MM to VX.y format.
* XML documentation updates.
  
<br/>

***

[❰ Back to DVN repository](../../README.md)