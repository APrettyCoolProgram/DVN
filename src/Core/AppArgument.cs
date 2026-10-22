// 261005_code
// 261021_documentation

using dvn.Core.Resources;
using dvn.DevelopmentEnvironment;

namespace dvn.Core;

/// <summary>Methods for handling and processing arguments passed via the command line.</summary>
internal class AppArgument
{
    /// <summary>The DVN command.</summary>
    /// <remarks>
    /// The DVN command:
    /// <list type="bullet">
    /// <item>Is required</item>
    /// <item>Is the first argument passed via the command line</item>
    /// </list>
    /// </remarks>
    /// <value>Examples include <c>about</c>, <c>help</c>, <c>list</c>, and <c>new</c>.</value>
    public string? Command { get; set; }

    /// <summary>The DVN option(s).</summary>
    /// <remarks>
    /// Options must:
    /// <list type="bullet">
    /// <item>Start with the "<c>-</c>" character</item>
    /// <item>Be a single character (e.g. "<c>b</c>")</item>
    /// <item>Be separated by a space</item>
    /// </list>
    /// For example: "dvn %environment% <b><c>-a</c> <c>-b</c></b>" <br/> <br/> There can be any number of options, but
    /// only valid options are processed.<br/>
    /// </remarks>
    /// <value>Examples include <c>-b</c></value>
    public List<string> Options { get; set; }

    /// <summary>Builds an <see cref="AppArgument"/> instance.</summary>
    /// <param name="passedArguments">The arguments passed via the command line.</param>
    /// <returns>An <see cref="AppArgument"/> object containing the parsed command and, potentially, options.</returns>
    internal static AppArgument GetComponents(string[] passedArguments) =>
        new()
        {
            Command = passedArguments[0].ToLower().Trim(),
            Options = passedArguments.Length >= 2
                        ? [.. passedArguments[1..].Select(arg => arg.ToLower().Trim())]
                        : []
        };

    /// <summary>Parses the command component of the arguments passed via the command-line.</summary>
    /// <remarks>
    /// Entering a command that does not match any of the case statements will either:
    /// <list type="bullet">
    /// <item>Start the <c>%command%</c> environment, if a <c>"%command%.dvn"</c> file exists.</item>
    /// <item>If a <c>"%command%.dvn"</c> file does not exist, create it with default values.</item>
    /// </list>
    /// </remarks>
    /// <param name="appState">The current <see cref="AppState"/> instance being initialized.</param>
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
                Launcher.DisplayDetails();
                break;

            case "new":
                Manifest.CreateEmpty();
                break;

            default:
                appState.DvnManifest = Manifest.Load(appState);
                Launcher.Launch(appState);
                break;
        }
    }
}