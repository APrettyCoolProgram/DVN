// 261020_code
// 261020_documentation

using dvn.Core.Resources;
using dvn.Du;

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

    /// <summary>Displays a list of available environments to the console.</summary>
    internal static void DisplayDetails()
    {
        Dictionary<string, string> environmentDetails = GetDetails();

        if (environmentDetails.Count == 0)
        {
            AppState.SpinDown(UsrMsg.MsgEnvList("No environments found."));
        }
        else
        {
            Console.WriteLine(UsrMsg.MsgEnvList(DuDictionary.ConvertToString(environmentDetails, "    ", "")));
        }
    }

    /// <summary>Get environment details</summary>
    /// <returns>
    /// TBD
    /// </returns>
    private static Dictionary<string, string> GetDetails()
    {
        var manifestFiles = Directory.GetFiles(".", "*.dvn", SearchOption.TopDirectoryOnly);

        Dictionary<string, string> environmentDetails = new Dictionary<string, string>();

        foreach (var manifestFile in manifestFiles)
        {
            DvnManifest dvnManifest = DuJson.ImportLocalFile<DvnManifest>(manifestFile);

            environmentDetails[dvnManifest.DevelopmentEnvironment.Name] = dvnManifest.DevelopmentEnvironment.Description;
        }

        return environmentDetails;
    }

    // TODO - Remove before release
    /// <summary>Displays a list of available environment names.</summary>
    /// <remarks>
    /// This is mostly used for development troubleshooting and testing.
    /// </remarks>
    internal static void DisplayNames()
    {
        string[] availableNames = GetNames();

        if (availableNames.Length == 0)
        {
            AppState.SpinDown(UsrMsg.MsgEnvList("No environments found."));
        }
        else
        {
            Console.WriteLine($"{availableNames.Length} environment(s) found:");
            Console.WriteLine(string.Join(Environment.NewLine, availableNames));
        }
    }

    // TODO - Remove before release
    private static string[] GetNames()
    {
        return Directory.GetFiles(".", "*.dvn", SearchOption.TopDirectoryOnly)
                        .Select(Path.GetFileNameWithoutExtension)
                        .ToArray();
    }
}