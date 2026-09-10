// 260910_code
// 260910_documentation

using dvn.Core.Resources;

namespace dvn.Core;

/// <summary>Logic for the DVN framework.</summary>
/// <remarks>
///     The <see cref="Framework"/> class contains the definitions for:<br/>
///     <list type="bullet">
///         <item>A list of <see cref="RequiredFiles">files</see> required by DVN.</item>
///         <item>A list of <see cref="RequiredFolders">folders</see> required by DVN.</item>
///     </list>
/// </remarks>
internal class Framework
{
    /// <summary>Files required by DVN.</summary>
    internal Dictionary<string, string> RequiredFiles { get; set; }

    /// <summary>Folders required by DVN.</summary>
    internal Dictionary<string, string> RequiredFolders { get; set; }

    /// <summary>Verifies that the DVN framework exists.</summary>
    /// <remarks>If the DVN framework does not exist, it will be created.</remarks>
    /// <param name="frameworkBase">The base path for the DVN framework.</param>
    internal static void VerifyExists(string frameworkBase)
    {
        if (!Directory.Exists(frameworkBase))
        {
            CreateNew();
        }
    }

    private static void CreateNew()
    {
        Console.WriteLine(UsrMsg.MsgCreateFramework);

        var dvnFramework = Build();

        Validate(dvnFramework);

        Session.Stop();
    }

    /// <summary>Constructs and returns a new instance of the <see cref="Framework"/> class.</summary>
    /// <remarks>
    ///     The <see cref="Framework"/> instance contains:<br/>
    ///     <list type="bullet">
    ///         <item>The list of <see cref="RequiredFiles">files</see> required by DVN.</item>
    ///         <item>The list of <see cref="RequiredFolders">folders</see> required by DVN.</item>
    ///     </list>
    /// </remarks>
    /// <returns>A <see cref="Framework"/> object.</returns>
    internal static Framework Build()
    {
        Dictionary<string, string> folders = BuildFolderDictionary();
        Dictionary<string, string> files   = BuildFileDictionary(folders);

        return new Framework
        {
            RequiredFolders = folders,
            RequiredFiles   = files
        };
    }

    /// <summary>Builds a dictionary of folder details required by DVN.</summary>
    /// <remarks>The dictionary key represents the folder identifier, and the value is the full path to the folder.</remarks>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> of folder identifiers and paths.</returns>
    internal static Dictionary<string, string> BuildFolderDictionary()
    {
        return new Dictionary<string, string>
        {
            { "Root"         , @".\" },
            { "Backups"      , @".\.dvn\bckp" },
            { "Configs"      , @".\.dvn\cnfg" },
            { "Manifests"    , @".\.dvn\mnfst" },
            { "Staging"      , @".\.dvn\stg" },
            { "Temporary"    , @".\.dvn\tmp" },
            { "Trash"        , @".\.dvn\trsh" },
        };
    }

    /// <summary>Builds a dictionary of file details required by DVN.</summary>
    /// <remarks>The dictionary key represents the file identifier, and the value is the full path to the file.</remarks>
    /// <param name="folders">A dictionary containing DVN folder paths.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> of file identifiers and paths.</returns>
    internal static Dictionary<string, string> BuildFileDictionary(Dictionary<string, string> folders) =>
        new Dictionary<string, string>
        {
            { "ConfigFile", $@"{folders["Configs"]}\dvn.cnfg" }
        };

    /// <summary>Validates the DVN framework.</summary>
    /// <param name="dvnFramework">The framework details to validate.</param>
    internal static void Validate(Framework dvnFramework)
    {
        ValidateFolders(dvnFramework.RequiredFolders);
        ValidateFiles(dvnFramework.RequiredFiles);
    }

    /// <summary>Validates required files exist.</summary>
    /// <remarks>If the file does not exist, it is created.</remarks>
    /// <param name="files">The <see cref="Framework.RequiredFiles"/> object containing file details.</param>
    internal static void ValidateFiles(Dictionary<string, string> files)
    {
        if (!File.Exists(files["ConfigFile"]))
        {
            Configuration.CreateNew(files["ConfigFile"]);
        }
    }

    /// <summary>Validates required folders exist.</summary>
    /// <remarks>If the folder does not exist, it is created.</remarks>
    /// <param name="folders">The <see cref="Framework.RequiredFolders"/> object containing folder details.</param>
    internal static void ValidateFolders(Dictionary<string, string> folders)
    {
        foreach (var folder in folders)
        {
            if (!Directory.Exists(folder.Value))
            {
                Directory.CreateDirectory(folder.Value);
            }
        }
    }
}