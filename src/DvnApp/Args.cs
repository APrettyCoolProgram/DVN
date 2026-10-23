// 261023_code
// 261023_documentation

namespace dvn.DvnApp;

/// <summary>Methods for handling and processing arguments passed via the command line.</summary>
internal class Args
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

    /// <summary>Builds an <see cref="Args"/> instance.</summary>
    /// <param name="args">The arguments passed via the command line.</param>
    /// <returns>An <see cref="Args"/> object containing the parsed command and, potentially, options.</returns>
    internal static Args GetComponents(string[] args) =>
        new()
        {
            Command = args[0].ToLower().Trim(),
            Options = args.Length >= 2
                        ? [.. args[1..].Select(arg => arg.ToLower().Trim())]
                        : []
        };
}