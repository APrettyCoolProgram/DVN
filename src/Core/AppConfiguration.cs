// 261005_code
// 261005_documentation

using dvn.Core.Resources;

namespace dvn.Core;

/// <summary>Provides logic for DVN configuration settings.</summary>
/// <remarks>
/// The <see cref="AppConfiguration"/> class defines the structure of the DVN configuration file, which includes:
/// <list type="bullet">
/// <item>The <see cref="ExcludedFiles"> excluded files</see> during backup operations.</item>
/// <item>The <see cref="ExcludedFolders"> excluded folders</see> during backup operations.</item>
/// </list>
/// </remarks>
internal class AppConfiguration
{
    public bool ScoopEnabled { get; set; } = false;

    /// <summary>The list of files that are excluded when backing up data.</summary>
    /// <remarks>
    /// When backup operations are performed, the files specified in this list will be ignored and not included in the backup process.
    /// </remarks>
    public List<string> ExcludedFiles { get; set; } = Catalog.LstIgnoredFiles();

    /// <summary>The list of folders that are excluded when backing up data.</summary>
    /// <remarks>
    /// When backup operations are performed, the folders specified in this list will be ignored and not included in the backup process.
    /// </remarks>
    public List<string> ExcludedFolders { get; set; } = Catalog.LstIgnoredFolders();

    /// <summary>Loads the DVN configuration from a local file.</summary>
    /// <remarks>
    /// If the specified configuration file does not exist, a new configuration file is created with default values.
    /// </remarks>
    /// <param name="configFile">The path to the DVN configuration file.</param>
    /// <returns>An <see cref="AppConfiguration"/> object representing the DVN configuration.</returns>
    internal static AppConfiguration Load(string configFile)
    {
        if (!File.Exists(configFile))
        {
            Build(configFile);

            Console.WriteLine(UsrMsg.MsgCreateConfig());
        }

        return Du.DuJson.ImportLocalFile<AppConfiguration>(configFile);
    }

    /// <summary>Creates a new DVN configuration file using default settings at the specified path.</summary>
    /// <remarks>
    /// If the specified configuration file already exists, it will be overwritten with the default settings.
    /// </remarks>
    /// <param name="configFile">The file path where the DVN configuration will be created.</param>
    internal static void Build(string configFile)
    {
        Du.DuJson.ExportLocalFile<AppConfiguration>(new AppConfiguration(), $@"{configFile}");
    }
}