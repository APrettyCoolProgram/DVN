// 261005_code
// 261005_documentation

using dvn.Core.Manifest;
using dvn.Core.Resources;

namespace dvn.Core;

/// <summary>Methods for handling and processing arguments passed via the command line.</summary>
internal class AppArgument
{
    /// <summary>The DVN command.</summary>
    /// <remarks>There can only be one command, and it is always the first argument.</remarks>
    /// <value>The command portion of the input.</value>
    internal string Command { get; set; }

    /// <summary>The DVN options.</summary>
    /// <remarks>
    /// There can be any number of options, but only valid options are processed.<br/>
    /// <br/>
    /// Options must:
    /// <list type="bullet">
    /// <item>Be a single character</item>
    /// <item>Start with the <c>-</c> character</item>
    /// <item>Be separated by a space</item>
    /// </list>
    /// </remarks>
    /// <value>The parsed options.</value>
    internal List<string> Options { get; set; }

    /// <summary>Parses the specified command-line arguments into a <see cref="CommandLine"/> object.</summary>
    /// <param name="passedArguments">The arguments passed via the command line.</param>
    /// <returns>A <see cref="AppArgument"/> object containing the parsed command and, potentially, options.</returns>
    internal static AppArgument GetComponents(string[] passedArguments)
    {
        return new AppArgument
        {
            Command = passedArguments[0].ToLower().Trim(),
            Options = passedArguments.Length >= 2
                        ? [.. passedArguments[1..].Select(arg => arg.ToLower().Trim())]
                        : []
        };
    }

    /// <summary>Parses the command component of the arguments passed via the command-line.</summary>
    /// <remarks>
    /// Entering a command that does not match any of the case statements will either:
    /// <list type="bullet">
    /// <item>Start the <c>%command%</c> environment, if a <c>"%command%.dvn"</c> file exists.</item>
    /// <item>If a <c>"%command%.dvn"</c> file does not exist, create it with default values.</item>
    /// </list>
    /// </remarks>
    /// <param name="appState">The <see cref="ApplicationState"/> instance.</param>
    internal static void Parse(AppState appState)
    {
        switch (appState.AppArgs.Command)
        {
            case "about":
                Console.WriteLine(UsrMsg.MsgAbout);
                break;

            case "help":
                Console.WriteLine(UsrMsg.MsgHelp);
                break;

            case "list":
                //var environmentList = DvnEnvironment.GetEnvironmentDetails(appState.AppConfig.ManifestPath, appState.AppConfig.ManifestExtension);
                //DvnEnvironment.DisplayAvailable(environmentList);
                break;

            default:
                //DvnEnvironment.LoadFromManifest(appState);
                break;
        }
    }
}