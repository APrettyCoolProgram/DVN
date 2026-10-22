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

    //internal static void Launch(string manifestFolder, string manifestName, string manifestExtension, string stagingPath, List<string> dvnOptions, List<string> excludedFiles, List<string> excludedFolders)
    internal static void Launch(DvnManifest dvnManifest, AppState appState)
    {
        //DvnManifest dvnManifest = DuJson.ImportLocalFile<DvnManifest>($@"{manifestFolder}\{manifestName}{manifestExtension}");

        Console.WriteLine($"{Environment.NewLine}  Launching environment: {dvnManifest.DevelopmentEnvironment.Description}");

        if (Archiver.BackupData.IsBackupEnabled(dvnManifest.DevelopmentEnvironment.BackupEnabled, appState.AppArgs.Options))
        {
            //Archiver.BackupData.BackupFolders(dvnManifest.DevelopmentEnvironment.BackupSources, dvnManifest.DevelopmentEnvironment.BackupLocation, stagingPath, excludedFiles, excludedFolders);
        }
        else
        {
            Console.WriteLine("  Data backup functionality is disabled.");
        }

        DvnApplication.StartApplications(dvnManifest.EnvironmentApplications);
        DvnWebBrowser.OpenPages(dvnManifest.WebBrowser.BrowserPages);

        AppState.SpinDown(UsrMsg.MsgExit());
    }


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
            Console.WriteLine(UsrMsg.MsgEnvList(DuDictionary.ConvertToString(environmentDetails, "  ", "")));
        }
    }

    /// <summary>Get environment details</summary>
    /// <returns>
    /// A dictionary containing environment names as keys and their descriptions as values.
    /// </returns>
    private static Dictionary<string, string> GetDetails()
    {
        var manifestFiles = Directory.GetFiles(".", "*.dvn", SearchOption.TopDirectoryOnly);

        Dictionary<string, string> environmentDetails = [];

        foreach (var manifestFile in manifestFiles)
        {
            DvnManifest dvnManifest = DuJson.ImportLocalFile<DvnManifest>(manifestFile);

            environmentDetails[dvnManifest.DevelopmentEnvironment.Name] = dvnManifest.DevelopmentEnvironment.Description;
        }

        return environmentDetails;
    }
}