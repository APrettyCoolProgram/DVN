// 261020_code
// 261020_documentation

using System.Diagnostics;
using dvn.Core;
using dvn.Core.Resources;
using dvn.Du;

namespace dvn.DevelopmentEnvironment;

internal class Launcher
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

    internal static void Launch(AppState appState)
    {
        Console.WriteLine($"{Environment.NewLine}  Launching environment: {appState.DvnManifest.DevelopmentEnvironment.Description}");

        if (Archiver.BackupData.IsBackupEnabled(appState.DvnManifest.DevelopmentEnvironment.BackupEnabled, appState.AppArgs.Options))
        {
            Archiver.BackupData.BackupFolders(appState.DvnManifest.DevelopmentEnvironment.BackupSources, appState.DvnManifest.DevelopmentEnvironment.BackupLocation, appState.AppConfig.ExcludedFiles, appState.AppConfig.ExcludedFolders);
        }
        else
        {
            Console.WriteLine("  Data backup functionality is disabled.");
        }

        StartApplications(appState.DvnManifest.EnvironmentApplications);
        OpenPages(appState.DvnManifest.BrowserPages);

        AppState.SpinDown(UsrMsg.MsgExit());
    }

    /// <summary>Starts each application in the supplied list.</summary>
    /// <remarks>Currently this functionality only works on Windows systems.</remarks>
    /// <param name="applications">A list of <see cref="AppDetail"/> instances.</param>
    internal static void StartApplications(List<AppDetail> applications)
    {
        foreach (AppDetail app in applications)
        {
            if (string.IsNullOrEmpty(app.FileName))
            {
                Console.WriteLine($"  No applications found.");

            }
            else
            {
                Console.WriteLine($"  Starting application: {app.Name}");

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName         = app.FileName,
                        Arguments        = app.Arguments,
                        WorkingDirectory = app.WorkingDirectory,
                        UseShellExecute  = true,
                        CreateNoWindow   = false
                    }
                };

                _=process.Start();
            }
        }
    }


    /// <summary>Opens the specified pages in their respective browsers.</summary>
    /// <param name="browserPages">A dictionary containing browser names and their associated pages.</param>
    internal static void OpenPages(Dictionary<string, Dictionary<string, string>> browserPages)
    {
        foreach (var browser in browserPages)
        {
            if (browser.Value.Count == 0)
            {
                Console.WriteLine($"  No pages found for {browser.Key}.");
            }
            else
            {
                Console.WriteLine($"  Opening pages in {browser.Key}:");

                foreach (var page in browser.Value)
                {
                    Console.WriteLine($"    Opening: {page.Key}");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {browser.Key.ToLower()} {page.Value}"));
                }
            }
        }
    }

    /// <summary>Displays a list of available environments to the console.</summary>
    internal static void DisplayDetails()
    {
        Dictionary<string, string> environmentDetails = GetDetails();

        if (environmentDetails.Count == 0)
        {
            AppState.SpinDown(UsrMsg.MsgEnvironmentList("No environments found."));
        }
        else
        {
            Console.WriteLine(UsrMsg.MsgEnvironmentList(DuDictionary.ConvertToString(environmentDetails, "  ", "")));
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
            Manifest dvnManifest = DuJson.ImportLocalFile<Manifest>(manifestFile);

            environmentDetails[dvnManifest.DevelopmentEnvironment.Name] = dvnManifest.DevelopmentEnvironment.Description;
        }

        return environmentDetails;
    }
}
