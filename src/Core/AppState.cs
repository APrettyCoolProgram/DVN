// 261022_code
// 261022_documentation

using dvn.Core.Resources;
using dvn.Extensions;

namespace dvn.Core;

/// <summary>Represents the application runtime state.</summary>
/// <remarks>
/// The <see cref="AppState"/> class:
/// <list type="bullet">
/// <item>The information DVN needs to operate (configuration, arguments, and environments)</item>
/// <item>Starting and stopping the DVN application</item>
/// <item>Initializing a new DVN session</item>
/// </list>
/// </remarks>
internal class AppState
{
    /// <summary>The DVN configuration settings.</summary>
    public AppConfiguration? AppConfig { get; set; }

    //internal ScoopConfiguration ScoopConfig { get; set; }

    /// <summary>The command-line arguments that are passed to DVN at runtime.</summary>
    public AppArgument? AppArgs { get; set; }

    public DvnManifest? DvnManifest { get; set; }

    /// <summary>Starts the DVN application.</summary>
    /// <param name="passedArguments">The command-line arguments passed to DVN at runtime.</param>
    internal static void SpinUp(string[] passedArguments)
    {
        Console.Clear();

        Console.WriteLine(UsrMsg.MsgStart);

        if (passedArguments == null || passedArguments.Length == 0)
        {
            SpinDown(UsrMsg.MsgMissingArguments);
        }
        else
        {
            NewSession(passedArguments);
        }
    }

    /// <summary>Initializes a new DVN session.</summary>
    /// <param name="passedArguments">The command-line arguments passed to DVN at runtime.</param>
    private static void NewSession(string[] passedArguments)
    {
        var appConfig = AppConfiguration.Load();

        if (appConfig.ScoopSh.Enabled)
        {
            ScoopSh.Roundhouse(appConfig.ScoopSh);
        }

        var appState = new AppState
        {
            AppConfig   = appConfig,
            AppArgs     = AppArgument.GetComponents(passedArguments),
            DvnManifest = null
        };

        AppArgument.Parse(appState);
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