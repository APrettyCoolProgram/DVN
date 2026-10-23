// 261023_code
// 261023_documentation

using dvn.Deven;
using dvn.DvnApp.Resource;
using dvn.Extension;

namespace dvn.DvnApp;

internal class FlightPath
{
    /// <summary>Starts the DVN application.</summary>
    /// <param name="args">The command-line arguments passed to DVN at runtime.</param>
    internal static void SpinUp(string[] args)
    {
        Console.Clear();

        Console.WriteLine(UsrMsg.MsgStartDvn);

        if (args == null || args.Length == 0)
        {
            SpinDown(UsrMsg.MsgMissingArgs);
        }
        else
        {
            TheState theState = TheState.NewState(args);

            if (theState.Config.ScoopSh.Enabled)
            {
                ScoopSh.Roundhouse(theState.Config.ScoopSh);
            }

            Roundhouse(theState);
        }
    }

    /// <summary>Parses the command component of the arguments passed via the command-line.</summary>
    /// <remarks>
    /// Entering a command that does not match any of the case statements will either:
    /// <list type="bullet">
    /// <item>Start the <c>%command%</c> environment, if a <c>"%command%.dvn"</c> file exists.</item>
    /// <item>If a <c>"%command%.dvn"</c> file does not exist, create it with default values.</item>
    /// </list>
    /// </remarks>
    /// <param name="theState">The current <see cref="TheState"/> instance being initialized.</param>
    internal static void Roundhouse(TheState theState)
    {
        switch (theState.Args.Command)
        {
            case "about":
                Console.WriteLine(UsrMsg.MsgAboutDvn);
                break;

            case "help":
                Console.WriteLine(UsrMsg.MsgDvnHelp);
                break;

            case "list":
                Details.DisplayDetails();
                break;

            case "new":
                Manifest.CreateEmpty();
                break;

            default:
                theState.Manifest = Manifest.Load($@".\{theState.Args.Command}.dvn");
                Launcher.Launch(theState.Manifest, theState.Args.Options, theState.Config.ExcludedFiles, theState.Config.ExcludedFolders);
                break;
        }
    }

    /// <summary>Stops the DVN application.</summary>
    /// <param name="exitMessage">The message to display before the DVN application exits.</param>
    /// <remarks>
    /// If a custom message is not provided, the default message will be displayed.
    /// </remarks>
    internal static void SpinDown(string exitMessage = "")
    {
        Console.WriteLine(exitMessage);

        Environment.Exit(0);
    }
}
