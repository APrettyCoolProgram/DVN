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

    internal static string[] GetEnvironmentNames()
    {
        return Directory.GetFiles(".", "*.dvn", SearchOption.TopDirectoryOnly)
                        .Select(Path.GetFileNameWithoutExtension)
                        .ToArray();
    }

    //internal static Dictionary<string, string> GetAvailableDetails)
    //{
    //    //var manifestList = Directory.GetFiles(@".\manifest", $"*.dvn", SearchOption.AllDirectories);
    //    var manifestList = Directory.GetFiles(".", "*.dvn", SearchOption.TopDirectoryOnly);

    //    Dictionary<string, string> environmentDetails = new Dictionary<string, string>();

    //    foreach (var manifest in manifestList)
    //    {
    //        DvnManifest manifest = DuJsonSystemTextJson.ImportFromLocalFile<DvnManifest>(manifest);

    //        environmentDetails[manifest.DevelopmentEnvironment.Name] = manifest.DevelopmentEnvironment.Description;
    //    }

    //    return environmentDetails;
    //}

    /// <summary>Displays a list of available environment names.</summary>
    /// <param name="availableNames">An array containing the names of available environments.</param>
    /// <remarks>
    /// This is mostly used for development troubleshooting and testing.
    /// </remarks>
    internal static void DisplayAvailableNames()
    {
        string[] availableNames = GetEnvironmentNames();

        if (availableNames.Length == 0)
        {
            AppState.Stop(UsrMsg.MsgEnvList("No environments found."));
        }
        else
        {
            Console.WriteLine($"{availableNames.Length} environment(s) found:");
            Console.WriteLine(string.Join(Environment.NewLine, availableNames));
        }
    }

    /// <summary>Displays a list of available environments to the console.</summary>
    /// <param name="availableEnvironments">A dictionary containing environment names and descriptions.</param>
    internal static void DisplayAvailableDetails(Dictionary<string, string> availableEnvironments)
    {
        if (availableEnvironments.Count == 0)
        {
            AppState.Stop(UsrMsg.MsgEnvList("No environments found."));
        }
        else
        {
            Console.WriteLine(UsrMsg.MsgEnvList(DuDictionary.ConvertToString(availableEnvironments, "    ", "")));
        }
    }
}