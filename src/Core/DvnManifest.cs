// 261020_code
// 261020_documentation

using dvn.Core.Manifest;

namespace dvn.Core;

internal class DvnManifest
{
    /// <summary>The development environment definition.</summary>
    public DvnEnvironment DevelopmentEnvironment { get; set; }

    /// <summary>The applications associated with the environment.</summary>
    public List<_DvnApplication> EnvironmentApplications { get; set; }

    /// <summary>The web browser configuration for the environment.</summary>
    public DvnWebBrowser WebBrowser { get; set; }

    /// <summary>Creates a default instance of the <see cref="_DvnManifest"/> class.</summary>
    internal static void CreateEmpty()
    {
        var dvnManifest = new DvnManifest()
        {
            DevelopmentEnvironment = new DvnEnvironment
            {
                Name          = "Environment name",
                Description   = "Environment description.",
                BackupEnabled = false,
            },
            EnvironmentApplications =
            [
                new _DvnApplication()
            ],
            WebBrowser = new DvnWebBrowser()
            {
                BrowserPages = new Dictionary<string, Dictionary<string, string>>()
                {
                    { "Chrome",  new Dictionary<string, string>() },
                    { "Firefox",  new Dictionary<string, string>() },
                    { "IExplore", new Dictionary<string, string>() }
                }
            }
        };

        //TODO Split this out into a separate method.

        Du.DuJson.ExportLocalFile(dvnManifest, "empty-manifest.dvn");
        //DuJson.ExportLocalFile(dvnManifest, $@"{manifestFolder}\{manifestName}{manifestExtension}");

        Console.WriteLine(Resources.UsrMsg.MsgCreateManifest("empty-manifest"));

        AppState.Stop();
    }

}
