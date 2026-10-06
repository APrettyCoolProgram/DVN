// 261006_code
// 261006_documentation

namespace dvn.Core;

internal class DvnEnvironment
{
    /// <summary>The environment name.</summary>
    public string Name { get; set; }

    /// <summary>The environment description.</summary>
    public string Description { get; set; }

    /// <summary>Indicates whether data should be backed up.</summary>
    public bool BackupEnabled { get; set; }

    /// <summary>The source directories to back up.</summary>
    public List<string> BackupSources { get; set; }

    /// <summary>The destination path for backups.</summary>
    public string BackupLocation { get; set; }

    internal static Dictionary<string, string> GetAvailable()
    {
        var manifestList = Directory.GetFiles(@".\manifest", $"*.dvn", SearchOption.AllDirectories);

        Dictionary<string, string> environmentDetails = [];

        foreach (var manifest in manifestList)
        {
            //DvnManifest manifest = DuJsonSystemTextJson.ImportFromLocalFile<DvnManifest>(manifest);

            //environmentDetails[manifest.DevelopmentEnvironment.Name] = manifest.DevelopmentEnvironment.Description;
        }

        return environmentDetails;
    }
}
