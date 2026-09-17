// 260917_code
// 260917_documentation

using dvn.Core.CommandLine;
using dvn.Core.Manifest;
using dvn.Core.Resources;

namespace dvn.Core;

/// <summary>Session logic.</summary>
/// <remarks>
/// A <c>session</c> is a single instance of DVN.<br/>
/// <br/>
/// When DVN is executed, a <i>Session instance</i> is created, which contains all the necessary components that DVN
/// needs to do its job, including:
/// <list type="bullet">
/// <item>The DVN <see cref="App.Configuration">configuration</see></item>
/// <item>The <see cref="App.CommandLine">arguments</see> passed to DVN</item>
/// <item>The DVN <see cref="App.Framework">framework</see> information</item>
/// <item>The list of available <see cref="DvnEnvironment">environments</see></item>
/// </list>
/// <br/>
/// When DVN is closed, the <i>Session instance</i> is disposed of.
/// </remarks>
internal class AppState
{
    /// <summary>The <see cref="Core.AppConfig"/> instance.</summary>
    internal AppConfig AppConfig { get; set; }

    /// <summary>The <see cref="Core.CommandLine.Arguments"/> component.</summary>
    internal Arguments Arguments { get; set; }

    /// <summary>A list of the available environment names and descriptions.</summary>
    internal Dictionary<string, string> AvailableEnvironments { get; set; }

    /// <summary>Starts a new DVN session.</summary>
    /// <remarks>The <c>".\.dvn"</c> folder is hard-coded here, since the DVN framework hasn't been initialized yet.</remarks>
    /// <param name="passedArguments">The DVN <see cref="CommandLine.Arguments"/> arguments passed to DVN.</param>
    internal static void Start(string[] passedArguments)
    {
        Console.Clear();

        Console.WriteLine(UsrMsg.MsgStart);

        AppConfig.Load(@".\dvn.config");

        if (Arguments.DoExist(passedArguments))
        {
            InitializeNew(passedArguments);
        }
        else
        {
            Stop(UsrMsg.MsgMissingArguments);
        }
    }

    /// <summary>Initializes a new DVN session.</summary>
    /// <param name="passedArguments">The DVN <see cref="CommandLine.CommandLine"/> arguments passed to DVN.</param>
    internal static void InitializeNew(string[] passedArguments)
    {
        var appState = new AppState
        {
            Arguments = Arguments.GetComponents(passedArguments),
        };

        Arguments.Parse(appState);
    }

    /// <summary>Terminates the application with an optional exit message.</summary>
    /// <param name="exitMessage">The message to display before the application exits.</param>
    internal static void Stop(string exitMessage = "")
    {
        Console.WriteLine(exitMessage);

        Environment.Exit(0);
    }
}