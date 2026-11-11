// 261023_code
// 261026_documentation

using dvn.DvnApp.Resource;
using dvn.Extension;

namespace dvn.DvnApp;

/// <summary>Defines the structure and behavior of the DVN configuration.</summary>
internal class Config
{
    /// <summary>The list of files that are excluded when backing up data.</summary>
    /// <remarks>
    /// When backup operations are performed, the files specified in this list will be ignored and not included in the
    /// backup process.
    /// </remarks>
    public List<string> ExcludedFiles { get; set; } = Catalog.LstExcludedFiles();

    /// <summary>The list of folders that are excluded when backing up data.</summary>
    /// <remarks>
    /// When backup operations are performed, the folders specified in this list will be ignored and not included in the
    /// backup process.
    /// </remarks>
    public List<string> ExcludedFolders { get; set; } = Catalog.LstExcludedFolders();

    /// <summary>The ScoopSh configuration settings.</summary>
    public ScoopSh ScoopSh { get; set; } = new ScoopSh();

    /// <summary>Loads the DVN configuration from the <c>dvn.config</c> file.</summary>
    /// <remarks>
    /// If the <c>dvn.config</c> file does not exist, a new configuration file is created with default values.
    /// </remarks>
    /// <returns>
    /// An <see cref="Config"/> instance populated from the file, or the default configuration if the file is missing.
    /// </returns>
    internal static Config Load()
    {
        const string configFile = @".\dvn.config";

        if (!File.Exists(configFile))
        {
            Build(configFile);
        }

        return Du.DuJson.ImportLocalFile<Config>(configFile);
    }

    /// <summary>Creates a new DVN configuration file using default settings.</summary>
    /// <param name="configPath">The configuration file path.</param>
    internal static void Build(string configPath)
    {
        Du.DuJson.ExportLocalFile<Config>(new Config(), $"{configPath}");

        Console.WriteLine(UsrMsg.MsgCreateConfig);
    }
}