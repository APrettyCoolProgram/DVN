// 261026_code
// 261023_documentation

using System.Diagnostics;
using dvn.DvnApp;
using dvn.DvnApp.Resource;

namespace dvn.Deven;

internal static class Launcher
{
    internal static void Launch(Manifest manifest, List<string> options, List<string> excludedFiles, List<string> excludedFolders)
    {
        Console.WriteLine($"{Environment.NewLine}Launching environment: {manifest.Description}"); // TODO - UsrMsg

        Archiver.ArchiveData(manifest, options, excludedFiles, excludedFolders);
        StartApplications(manifest.Apps);
        OpenPages(manifest.Webpages);

        FlightPath.SpinDown(UsrMsg.MsgExitDvn());
    }

    /// <summary>Starts each application in the supplied list.</summary>
    /// <remarks>Currently this functionality only works on Windows systems.</remarks>
    /// <param name="applications">A list of <see cref="DevenApp"/> instances.</param>
    internal static void StartApplications(List<DevenApp>? applications)
    {
        if (applications == null || applications.Count == 0)
        {
            Console.WriteLine("  No applications found to launch."); // TODO - UsrMsg
        }
        else
        {
            foreach (DevenApp app in applications)
            {
                Console.WriteLine($"  Starting application: {app.Name}"); // TODO - UsrMsg

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
                Console.WriteLine($"  No pages found for {browser.Key}."); // TODO - UsrMsg
            }
            else
            {
                Console.WriteLine($"  Opening pages in {browser.Key}:"); // TODO - UsrMsg

                foreach (var page in browser.Value)
                {
                    Console.WriteLine($"    Opening: {page.Key}"); // TODO - UsrMsg
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {browser.Key.ToLower()} {page.Value}"));
                }
            }
        }
    }
}