// 261023_code
// 261026_documentation

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

            Roundhouse(theState);
        }
    }

    /// <summary>Determines what action to take based on the command/options provided.</summary>
    /// <remarks>
    /// If the users enters a command that does not match any of the case statements, DVN will attempt to load a development environment
    /// manifest file with the name of the command provided.
    /// </remarks>
    /// <param name="theState">The current <see cref="TheState"/> instance being initialized.</param>
    internal static void Roundhouse(TheState theState)
    {
        switch (theState.Args.Command)
        {
            case "about":
                Console.WriteLine(UsrMsg.MsgAboutDvn(theState.Config.ScoopSh.Enabled, theState.Config.ScoopSh.Update));
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
                // TODO - Move this closer to when a valid manifest is loaded.
                if (theState.Config.ScoopSh.Enabled)
                {
                    ScoopSh.Roundhouse(theState.Config.ScoopSh);
                }

                theState.Manifest = Manifest.Load($@".\{theState.Args.Command}.deven");
                Launcher.Launch(theState.Manifest, theState.Args.Options, theState.Config.ExcludedFiles, theState.Config.ExcludedFolders);
                break;
        }
    }

    /// <summary>Exits the DVN application.</summary>
    /// <param name="exitMessage">The message to display before the DVN application exits.</param>
    /// <remarks>
    /// If a custom message is not provided, no message will be displayed.
    /// </remarks>
    internal static void SpinDown(string exitMessage = "")
    {
        Console.WriteLine(exitMessage);

        Environment.Exit(0);
    }
}