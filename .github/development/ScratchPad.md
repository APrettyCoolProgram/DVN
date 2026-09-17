<div align="center">

  <h1>DVN: Scratchpad</h1>

</div>

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

/// <summary>Methods for handling and processing arguments passed via the <see cref="CommandLine"/>.</summary>
/// <remarks>
/// Valid <see cref="CommandLine.CmdLn"> commands</see>:
/// <list type="bullet">
/// <item><c>%environment%</c> - Loads or creates a <c>%environment%.dvn.manifest</c> file.</item>
/// <item><c>about</c> - Displays information about dvn.</item>
/// <item><c>help</c> - Displays help information.</item>
/// <item><c>list</c> - Lists all available development environments.</item>
/// </list>
/// Valid <see cref="CommandLine.Options"> options</see>:
/// <list type="bullet">
/// <item><c>-b</c> - Force the data backup functionality, potentially overriding the manifest file setting.</item>
/// </list>
/// </remarks>

    internal static Arguments GetComponents(string[] passedArguments) =>
        new Arguments()
        {
            Command = passedArguments[0].ToLower().Trim(),
            Options = passedArguments.Length < 2
                      ? []
                      : [.. passedArguments[1..].Select(arg => arg.ToLower().Trim())]
        };


***

<br>

<sub>Last updated: 260417</sub>
