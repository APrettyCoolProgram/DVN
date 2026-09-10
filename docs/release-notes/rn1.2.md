<div align="center">

  <img src="../../.github/logo/dvn-Logo-384x184.png" alt="DVN">
</div>

> [!NOTE]
> This release focuses on:
>
> * [Code refactors](#code-refactors)
> * [Framework updates](#framework-updates)

***

## Code refactors

* `Core.Catalog.cs` methods that return lists have a `lst_` prefix (changed from `cat_` )

## Framework updates

* `apps\` and `data\` directories have been removed  
  The original concept of dvn was grander in scale, and these directories were meant to hold various applications and data files that would be used by dvn. As the project evolved, I decided to focus on the core functionality of dvn, and move some of the planned features to [Deven](https://github.com/APrettyCoolProgram/Deven). As a result, these directories are no longer necessary for dvn, and have been removed to simplify the project structure.

## Misc

* XML Documentation updates
