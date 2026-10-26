// 261023_code
// 261026_documentation

using dvn.Deven;

namespace dvn.DvnApp;

/// <summary>Represents the application runtime state.</summary>
/// <remarks>
/// The <see cref="TheState"/> class encapsulates the current state of the DVN application, including:
/// <list type="bullet">
/// <item>The DVN <see cref="Config">configuration settings</see></item>
/// <item>The command-line <see cref="Args">arguments</see> passed to DVN at runtime</item>
/// <item>DVN development environment <see cref="Manifest">manifest</see></item>
/// </list>
/// </remarks>
internal class TheState
{
    /// <summary>The DVN configuration settings.</summary>
    public Config? Config { get; set; }

    /// <summary>The command-line arguments that are passed to DVN at runtime.</summary>
    public Args? Args { get; set; }

    /// <summary>The development environment manifest object.</summary>
    public Manifest? Manifest { get; set; }

    /// <summary>Initializes a new DVN state.</summary>
    /// <param name="args">The command-line arguments passed to DVN at runtime.</param>
    internal static TheState NewState(string[] args) =>
        new()
        {
            Config   = Config.Load(),
            Args     = Args.GetComponents(args),
            Manifest = null
        };
}