// 260917_code
// 260917_documentation

using dvn.Core.Resources;

namespace dvn.Core.Manifest;

/// <summary>Logic for development environments.</summary>
internal class _DvnEnvironment
{
    /// <summary>Loads an environment manifest file.</summary>
    /// <remarks>If the specified manifest file does not exist, a new manifest file is created.</remarks>
    /// <param name="dvnSession">The session instance.</param>
    internal static void LoadFromManifest(AppState dvnSession)
    {
        //if (File.Exists($@"{dvnSession.Framework.RequiredFolders["Manifests"]}\{dvnSession.CommandLine.Command}{dvnSession.AppConfig.ManifestExtension}"))
        //{
        //    Launch(dvnSession.Framework.RequiredFolders["Manifests"], dvnSession.CommandLine.Command, dvnSession.AppConfig.ManifestExtension,
        //           dvnSession.Framework.RequiredFolders["Staging"], dvnSession.CommandLine.Options, dvnSession.AppConfig.ExcludedFiles,
        //           dvnSession.AppConfig.ExcludedFolders);
        //}
        //else
        //{
        //    DvnManifest.CreateDefault(dvnSession.Framework.RequiredFolders["Manifests"], dvnSession.CommandLine.Command, dvnSession.AppConfig.ManifestExtension);

        //    AppState.Stop();
        //}
    }

    /// <summary>Launches a development environment.</summary>
    /// <param name="manifestFolder">The folder path where the manifest file is located.</param>
    /// <param name="manifestName">The name of the manifest file without extension.</param>
    /// <param name="manifestExtension">The file extension of the manifest.</param>
    /// <param name="stagingPath">The path to the staging area for backup operations.</param>
    /// <param name="dvnOptions">A list of options that modify the behavior of the launch process.</param>
    /// <param name="excludedFiles">A list of file names to exclude from backup operations.</param>
    /// <param name="excludedFolders">A list of folder names to exclude from backup operations.</param>
    internal static void Launch(string manifestFolder, string manifestName, string manifestExtension, string stagingPath, List<string> dvnOptions, List<string> excludedFiles, List<string> excludedFolders)
    {
        //_DvnManifest dvnManifest = DuJson.ImportLocalFile<_DvnManifest>($@"{manifestFolder}\{manifestName}{manifestExtension}");

        //Console.WriteLine($"{Environment.NewLine}  Launching environment: {dvnManifest.DevelopmentEnvironment.Description}");

        //if (Archiver.BackupData.IsBackupEnabled(dvnManifest.DevelopmentEnvironment.BackupEnabled, dvnOptions))
        //{
        //    Archiver.BackupData.BackupFolders(dvnManifest.DevelopmentEnvironment.BackupSources, dvnManifest.DevelopmentEnvironment.BackupLocation, stagingPath, excludedFiles, excludedFolders);
        //}
        //else
        //{
        //    Console.WriteLine("  Data backup functionality is disabled.");
        //}

        //_DvnApplication.StartApplications(dvnManifest.EnvironmentApplications);
        //_DvnWebBrowser.OpenPages(dvnManifest.WebBrowser.BrowserPages);

        AppState.SpinDown(UsrMsg.MsgExit());
    }
}