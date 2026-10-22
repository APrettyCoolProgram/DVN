// 261020_code
// 261020_documentation

using dvn.Core;

namespace dvn.DevelopmentEnvironment;

internal class Manifest
{
    /// <summary>The development environment definition.</summary>
    public Launcher? DevelopmentEnvironment { get; set; }

    /// <summary>The applications associated with the environment.</summary>
    public List<AppDetail>? EnvironmentApplications { get; set; }

    /// <summary>The web browser configuration for the environment.</summary>
    /// <summary>A dictionary containing browser names and their associated pages.</summary>
    /// <remarks>
    /// The keys are the browser names (for example, <c>IExplore</c> or <c>Firefox</c>), and the values are dictionaries
    /// where the keys are page titles and the values are URLs.
    /// </remarks>
    public Dictionary<string, Dictionary<string, string>> BrowserPages { get; set; }

    internal static Manifest Load(AppState appState)
    {
        string manifestPath = $@".\{appState.AppArgs.Command}.dvn";

        if (!File.Exists(manifestPath))
        {
            AppState.SpinDown();
            return null;
        }
        else
        {
            var dvnManifest = Du.DuJson.ImportLocalFile<Manifest>(manifestPath);
            //DvnEnvironment.Launch(dvnManifest, appState);
            return dvnManifest;
        }
    }

    /// <summary>Creates a default instance of the <see cref="Manifest"/> class.</summary>
    internal static void CreateEmpty()
    {
        var dvnManifest = new Manifest()
        {
            DevelopmentEnvironment = new Launcher
            {
                Name          = "Environment name",
                Description   = "Environment description.",
                BackupEnabled = false,
            },
            EnvironmentApplications =
            [
                new AppDetail()
            ],
            BrowserPages = new Dictionary<string, Dictionary<string, string>>()
            {
                { "Chrome",   new Dictionary<string, string>() },
                { "Firefox",  new Dictionary<string, string>() },
                { "IExplore", new Dictionary<string, string>() }
            }
        };

        //TODO Split this out into a separate method.

        Du.DuJson.ExportLocalFile(dvnManifest, "empty-manifest.dvn");

        Console.WriteLine(Resources.UsrMsg.MsgCreateManifest("empty-manifest"));

        AppState.SpinDown();
    }
}