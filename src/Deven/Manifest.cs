// 261026_code
// 261023_documentation

using dvn.DvnApp;
using dvn.DvnApp.Resource;

namespace dvn.Deven;

internal class Manifest
{
    /// <summary>The environment name.</summary>
    public string Name { get; set; }

    /// <summary>The environment description.</summary>
    public string Description { get; set; }

    /// <summary>Indicates whether data should be archived.</summary>
    public bool ArchiveEnabled { get; set; }

    /// <summary>The source directories to archive.</summary>
    public List<string> ArchiveSource { get; set; }

    /// <summary>The destination path for archives.</summary>
    public string ArchiveTarget { get; set; }

    /// <summary>The applications associated with the environment.</summary>
    public List<DevenApp>? Apps { get; set; }

    /// <summary>The web browser configuration for the environment.</summary>
    /// <summary>A dictionary containing browser names and their associated pages.</summary>
    /// <remarks>
    /// The keys are the browser names (for example, <c>IExplore</c> or <c>Firefox</c>), and the values are dictionaries
    /// where the keys are page titles and the values are URLs.
    /// </remarks>
    public Dictionary<string, Dictionary<string, string>> Webpages { get; set; }

    public string Logging { get; set; }

    internal static Manifest Load(string manifestPath)
    {
        if (File.Exists(manifestPath))
        {
            return Du.DuJson.ImportLocalFile<Manifest>(manifestPath);
        }
        else
        {
            FlightPath.SpinDown(UsrMsg.MsgManifestNotFound(manifestPath));

            return null;
        }
    }

    /// <summary>Creates a default instance of the <see cref="Manifest"/> class.</summary>
    internal static void CreateEmpty()
    {
        var manifest = new Manifest()
        {
            Name           = "Name",
            Description    = "Description.",
            ArchiveEnabled = false,
            ArchiveSource =
            [
                "Path\\To\\Source1",
                "Path\\To\\Source2"
             ],
            ArchiveTarget  = "Path\\To\\Target",
            Apps =
            [
                new()
            ],
            Webpages = new Dictionary<string, Dictionary<string, string>>()
            {
                { "Chrome",   new Dictionary<string, string>() },
                { "Firefox",  new Dictionary<string, string>() },
                { "IExplore", new Dictionary<string, string>() }
            },
            Logging = "disabled"
        };

        Du.DuJson.ExportLocalFile(manifest, "new.deven");

        Console.WriteLine(UsrMsg.MsgCreateManifest("new"));

        FlightPath.SpinDown();
    }
}