❰ [DVN](../README.md) ❬ Changelog

<div align="center">

  <img src="../.github/logo/dvn-Logo-384x184.png" alt="DVN">

  <h1>Changelog</h1>

</div>

# Version 2.0 - 2026-9-17

> This is a major update that focuses on simplifying the framework and integrating basic Scoop.sh functionality.
>
> Please see the [release notes](rn/rn2.0.md) for more details.

* **NEW** Basic Scoop.sh integration
* **NEW** Display version number is displayed when DVN is executed
* **ADDED** `Ns:dvn.Core.CommandLine`
* **ADDED** `Ns:dvn.Core.Resources`
* **CHANGED** `dvn.Core.Arguments.cs` -> `dvn.Core.CommandLine.Arguments.cs`
* **CHANGED** `dvn.Blueprint.Catalog.cs` -> `dvn.Core.Resources.Catalog.cs`
* **CHANGED** `dvn.Blueprint.UserMessage.cs` -> `dvn.Core.Resources.UsrMsg.cs`
* **CHANGED** `lst_` prefix -> `Lst` in `dvn.Core.Resources.UsrMsg.cs`
* **CHANGED** `msg_` prefix -> `Msg` in `dvn.Core.Resources.UsrMsg.cs`
* **CHANGED** `AppConfig.LoadFromLocalFile()` -> `AppConfig.Load()`
* **CHANGED** Text formatting in `dvn.Core.Resources.UsrMsg.cs`
* **UPDATED** Target framework from `.NET 9` to `.NET 10`
* **UPDATED** XML documentation
* **UPDATED** `Du.DuJson.cs` from `b250801` to `b260909`
* **REMOVED** `Ns:dvn.Blueprint`
* **REMOVED** `dvn.Core.Framework.cs`
* **REMOVED** `List` command

***

## Version 1.2

> Please see the [release notes](rn/rn1.2.md) for more details.

* Code refactors
* Framework updates

***

## Version 1.1

> Please see the [release notes](rn/rn1.1.md) for more details.

* Additional web browser support

***

## Version 1.0

> Please see the [release notes](rn/rn1.0.md) for more details.

* Initial release of DVN.

<br/>

***

❰ [DVN](../README.md) ❬ Changelog


<!--
New
Added
Changed
Updated
Fixed
Depreciated
Removed
Security

-->