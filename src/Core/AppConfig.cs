// 260910_code
// 260910_documentation

using dvn.Core.Resources;

namespace dvn.Core;

/// <summary>Provides logic for DVN configuration settings.</summary>
/// <remarks>
/// The <see cref="AppConfig"/> class defines the structure of the DVN configuration file.
/// It includes:
/// <list type="bullet">
/// <item><see cref="ManifestExtension"/> used for DVN manifest files.</item>
/// <item><see cref="ExcludedFiles"/> excluded during backup operations.</item>
/// <item><see cref="ExcludedFolders"/> excluded during backup operations.</item>
/// </list>
/// </remarks>
internal class AppConfig
{
    /// <summary>The file extension used for manifest files.</summary>
    public string ManifestExtension { get; set; } = ".dvn";

    /// <summary>The list of files that are excluded when backing up data.</summary>
    public List<string> ExcludedFiles { get; set; } = Catalog.LstIgnoredFiles();

    /// <summary>The list of folders that are excluded when backing up data.</summary>
    public List<string> ExcludedFolders { get; set; } = Catalog.LstIgnoredFolders();

    /// <summary>Loads the DVN configuration from a local file.</summary>
    /// <remarks>
    /// If the specified configuration file does not exist, a new configuration file is created with default values.
    /// The newly created file is then loaded.
    /// </remarks>
    /// <param name="configFile">The path to the DVN configuration file.</param>
    /// <returns>A <see cref="AppConfig"/> object representing the DVN configuration.</returns>
    internal static AppConfig Load(string configFile)
    {
        if (!File.Exists(configFile))
        {
            Build(configFile);

            Console.WriteLine(UsrMsg.MsgCreateConfig());
        }

        return Du.DuJson.ImportFromLocalFile<AppConfig>(configFile);
    }

    /// <summary>Creates a new DVN configuration file using default settings at the specified path.</summary>
    /// <param name="configFile">The file path where the DVN configuration will be created.</param>
    internal static void Build(string configFile)
    {
        Du.DuJson.ExportToLocalFile<AppConfig>(new AppConfig(), $@"{configFile}");
    }
}