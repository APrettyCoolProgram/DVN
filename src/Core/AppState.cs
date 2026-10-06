// 261006_code
// 261006_documentation

using dvn.Core.Resources;

namespace dvn.Core;

/// <summary>AppState logic.</summary>
/// <remarks>
/// Each time DVN is executed, a new <i>session</i> is initialized.<br/>
/// <br/>
/// The <c>AppState</c> instance contains all of the information that a DVN <i>session</i> needs to do its job, including:
/// <list type="bullet">
/// <item>The DVN <see cref="AppConfig">configuration</see></item>
/// <item>The <see cref="AppArgs">arguments</see> passed to DVN</item>
/// <item>The list of available DVN <see cref="DvnEnvs">environments</see></item>
/// </list>
/// <br/>
/// When DVN exits, the session ends and the <c>AppState</c> instance is disposed of.
/// </remarks>
internal class AppState
{
    /// <summary>The <see cref="Core.AppConfig"/> instance.</summary>
    /// <remarks>
    /// The <c>AppConfig</c> contains the configuration settings, and is loaded from the <c>".\.dvn\dvn.config"</c> file.
    /// </remarks>
    internal AppConfiguration? AppConfig { get; set; }

    /// <summary>The <see cref="AppArgument"/> component.</summary>
    /// <remarks>
    /// The <c>AppArguments</c> component contains the command and options passed to DVN via the command line.
    /// </remarks>
    internal AppArgument? AppArgs { get; set; }

    /// <summary>A list of the available environment names and descriptions.</summary>
    internal Dictionary<string, string>? DvnEnvs { get; set; }

    /// <summary>Starts the DVN application.</summary>
    /// <param name="passedArguments">The DVN <see cref="AppArgument"/> arguments passed to DVN.</param>
    internal static void Start(string[] passedArguments)
    {
        Console.Clear();

        Console.WriteLine(UsrMsg.MsgStart);

        if (passedArguments == null || passedArguments.Length == 0)
        {
            Stop(UsrMsg.MsgMissingArguments);
        }
        else
        {
            NewSession(passedArguments);
        }
    }

    /// <summary>Terminates the application with an optional exit message.</summary>
    /// <param name="exitMessage">The message to display before the application exits.</param>
    internal static void Stop(string exitMessage = "")
    {
        Console.WriteLine(exitMessage);

        Environment.Exit(0);
    }

    /// <summary>Initializes a new DVN session by loading the configuration, parsing the arguments, and setting up the available environments.</summary>
    /// <param name="passedArguments">The DVN <see cref="AppArgument"/> arguments passed to DVN.</param>
    /// <param name="appConfig">The DVN <see cref="AppConfiguration"/> configuration.</param>
    private static void NewSession(string[] passedArguments)
    {
        var appConfig = AppConfiguration.Load(@".\dvn.config");

        if (appConfig.ScoopEnabled)
        {
            AppExtension.Scoop();
        }

        var appState = new AppState
        {
            AppConfig = appConfig,
            AppArgs   = AppArgument.GetComponents(passedArguments),
            DvnEnvs   = [] // TODO
        };

        AppArgument.Parse(appState);
    }
}