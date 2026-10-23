// 261023_code
// 261023_documentation

using System.IO.Compression;
using dvn.Du;

namespace dvn.Deven;

/// <summary>Logic related to backing up data.</summary>
internal static class Archiver
{
    internal static void ArchiveData(Manifest manifest, List<string> dvnOptions, List<string> excludedFiles, List<string> excludedDirs)
    {
        if (IsArchiveEnabled(manifest.ArchiveEnabled, dvnOptions))
        {
            ArchiveDeven(manifest.ArchiveSource, manifest.ArchiveTarget, excludedFiles, excludedDirs);
        }
        else
        {
            Console.WriteLine("  Data archive functionality is disabled."); // TODO UsrMsg
        }
    }

    /// <summary>Determines whether the data backup functionality is enabled.</summary>
    /// <remarks>
    /// The data backup functionality can be enabled by either:
    /// <list type="bullet">
    /// <item>Setting the <c>BackupEnabled</c> property in the manifest file to <c>true</c></item>
    /// <item>Passing the <c>-b</c> option via the command line</item>
    /// </list>
    /// Since the backup process can take a significant amount of time, the <c>BackupEnabled</c> property is set<br/>
    /// to <c>false</c> when a manifest file is created.<br/>
    /// <br/>
    /// The recommended method to enable backups is to use the <c>-b</c> option when executing dvn, which gives<br/>
    /// the user more control over when backups are performed.<br/>
    /// </remarks>
    /// <param name="manifest">The data archive flag in the manifest file.</param>
    /// <param name="dvnOptions">The data archive flag in the command line arguments.</param>
    /// <returns><c>true</c> if data archives are enabled, and <c>false</c> if they are not.</returns>
    internal static bool IsArchiveEnabled(bool manifest, List<string> dvnOptions) => manifest || dvnOptions.Contains("-b");

    /// <summary>Archives repository data.</summary>
    /// <param name="sources">The repository sources to archive.</param>
    /// <param name="target">Where the archives will be stored.</param>
    /// <param name="excludeFiles">The file names to exclude while staging.</param>
    /// <param name="excludeFolders">The directory names to exclude while staging.</param>
    internal static void ArchiveDeven(List<string> sources, string target, List<string> excludeFiles, List<string> excludeFolders)
    {
        const string staging = @".\.staging";

        CopyToStaging(sources, staging, excludeFiles, excludeFolders);

        foreach (var subDirectory in Directory.GetDirectories(staging))
        {
            Console.WriteLine($"  Archiving {subDirectory}...please wait...");

            var subDirectoryName = Path.GetFileName(subDirectory);
            var dateTimeStamp    = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            var archiveLocation  = Path.Combine(target, $"{subDirectoryName}_{dateTimeStamp}.zip");

            ZipFile.CreateFromDirectory(subDirectory, archiveLocation);

            Directory.Delete(staging, true);
        }
    }

    /// <summary>Copies specified source directories to a staging directory.</summary>
    /// <remarks>
    /// In order to keep archive sizes manageable, this method allows for the exclusion of specific files and directories.<br/>
    /// </remarks>
    /// <param name="sources">A list of source directory paths to be copied to the staging directory.</param>
    /// <param name="staging">The path to the staging directory where the source directories will be copied.</param>
    /// <param name="excludeFiles">A list of file names to exclude from the copy operation.</param>
    /// <param name="excludeFolders">A list of directory names to exclude from the copy operation.</param>
    internal static void CopyToStaging(List<string> sources, string staging, List<string> excludeFiles, List<string> excludeFolders)
    {
        DuDirectory.Reset(staging);

        foreach (var source in sources)
        {
            DuDirectory.CopyExclude(source, $@"{staging}\{source.Split("\\").Last()}", excludeFiles, excludeFolders, true);
        }
    }
}