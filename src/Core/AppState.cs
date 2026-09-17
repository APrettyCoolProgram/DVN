// 250801_code
// 260617_documentation

using dvn.Core.CommandLine;
using dvn.Core.Resources;
using dvn.Manifest;

namespace dvn.Core;

/// <summary>Session logic.</summary>
/// <remarks>
///     A <c>session</c> is a single instance of dvn.<br/>
///     <br/>
///     When dvn is executed, a <i>Session instance</i> is created, which contains all the necessary
///     components that dvn needs to do its job, including:
///     <list type="bullet">
///         <item>The dvn <see cref="App.Configuration">configuration</see></item>
///         <item>The <see cref="App.CommandLine">arguments</see> passed to dvn</item>
///         <item>The dvn <see cref="App.Framework">framework</see> information</item>
///         <item>The list of available <see cref="DvnEnvironment">environments</see></item>
///     </list>
///     <br/>
///     When dvn is closed, the <i>Session instance</i> is disposed of.
/// </remarks>
internal class AppState
{
    /// <summary>The <see cref="Core.AppConfig"/> instance.</summary>
    internal AppConfig AppConfig { get; set; }

    /// <summary>The <see cref="Core.CommandLine.CmdLn"/> component.</summary>
    internal CmdLn CmdLine { get; set; }

    /// <summary>A list of the available environment names and descriptions.</summary>
    internal Dictionary<string, string> AvailableEnvironments { get; set; }

    /// <summary>Starts a new dvn session.</summary>
    /// <remarks>The <c>".\.dvn"</c> folder is hard-coded here, since the dvn framework hasn't been initialized yet.</remarks>
    /// <param name="passedArguments">The dvn <see cref="CommandLine.CommandLine"/> arguments passed to dvn.</param>
    internal static void Start(string[] passedArguments)
    {
        Console.Clear();

        Console.WriteLine(UsrMsg.MsgStart);

        AppConfig.Load(@".\dvn.config");

        if (CommandLine.Arguments.DoExist(passedArguments))
        {
            InitializeNew(passedArguments);
        }
        else
        {
            Stop(UsrMsg.MsgMissingArguments);
        }
    }

    /// <summary>Initializes a new dvn session.</summary>
    /// <param name="passedArguments">The dvn <see cref="CommandLine.CommandLine"/> arguments passed to dvn.</param>
    internal static void InitializeNew(string[] passedArguments)
    {
        var dvnSession = new AppState
        {
            CmdLine = CmdLn.GetComponents(passedArguments),
        };

        Arguments.ParseCommand(dvnSession);
    }

    /// <summary>Terminates the application with an optional exit message.</summary>
    /// <param name="exitMessage">The message to display before the application exits.</param>
    internal static void Stop(string exitMessage = "")
    {
        Console.WriteLine(exitMessage);

        Environment.Exit(0);
    }
}