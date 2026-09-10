[❰ Back to DVN repository](../../README.md)

<div align="center">

  <img src="../../.github/logo/dvn-Logo-384x184.png" alt="DVN">

  <h2>Version 1.3 Release Notes</h2>

</div>

> [!NOTE]
> This release focuses on:
>
> * [Code refactors](#code-refactors)
> * [Adding basic support for Scoop](#adding-basic-support-for-scoop)
> * [Framework updates](#framework-updates)
> * [Updating dvn to .NET 10](#updated)

***

## Code refactors

* Added the `dvn.Core.Resources` namespace, which is the new standard location for blueprints, catalogs, etc.

* Moved the following files from `Ns:dvn.Blueprint` to `Ns:dvn.Core.Resources`:
  * `Catalog.cs`
  * `UserMessage.cs` (renamed to `UsrMsg.cs`)

* Changed the following method prefixes so they conform to the new naming conventions:
  * `lst_` to `Lst` in `dvn.Core.Resources.UsrMsg.cs`
  * `msg_` to `Msg` in `dvn.Core.Resources.UsrMsg.cs`

## Framework updates

* Renamed rn

## UPDATED



* Updated to .NET 10
* Updated all XML Documentation

## FIXED

No changes.

***

## REMOVED

* `apps\` and `data\` directories  
The original concept of dvn was grander in scale, and these directories were meant to hold various applications and data files that would be used by dvn. As the project evolved, I decided to focus on the core functionality of dvn, and move some of the planned features to [Deven](https://github.com/APrettyCoolProgram/Deven). As a result, these directories are no longer necessary for dvn, and have been removed to simplify the project structure.

***

## SECURITY

No changes.

## Misc

* Changed the release from RYY.MM to VX.y format.  
  This was mostly an internal change.
  
<br/>

***

[❰ Back to DVN repository](../../README.md)