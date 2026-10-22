// 260922_code
// 260922_documentation

namespace dvn.Core.Resources;

/// <summary>Predefined resources and data structures.</summary>
/// <remarks>
/// The <see cref="Catalog"/> class contains predefined resources and data structures that are used throughout the
/// source code, providing a centralized location for commonly used data, and allowing easy access and modification.
/// </remarks>
internal static class Catalog
{
    /// <summary>Files that should be excluded from the backup process.</summary>
    internal static List<string> LstExcludedFiles() =>
    [
        ".DS_Store",
        "Thumbs.db",
        "desktop.ini",
        "package-lock.json",
        "yarn.lock",
        "pnpm-lock.yaml",
        "npm-shrinkwrap.json"
    ];

    ///// <summary>Other files that should not be backed up.</summary>
    //internal static List<string> LstOtherIgnoredFiles =>
    //[
    //];

    /// <summary>Folders that should be excluded from the backup process.</summary>
    internal static List<string> LstExcludedFolders() =>
    [
        "node_modules",
        "bin",
        "obj",
        ".git",
        ".vs",
        ".vscode",
        ".idea",
        "packages"
    ];

    ///// <summary>Other folders that should not be backed up.</summary>
    //internal static List<string> LstOtherIgnoredFolders =>
    //[
    //];

    ///// <summary>Combines the configured file ignore lists.</summary>
    ///// <remarks>This is the list that is stored in the dvn.config file.</remarks>
    ///// <returns>A list of file names that should be ignored when copying.</returns>
    //internal static List<string> LstIgnoredFiles() =>
    //[.. LstRepositoryIgnoredFiles
    //    .Concat(LstOtherIgnoredFiles)
    //    .Distinct()
    //];

    ///// <summary>Combines the configured folder ignore lists.</summary>
    ///// <remarks>This is the list that is stored in the dvn.config file.</remarks>
    ///// <returns>A list of folder names that should be ignored when copying.</returns>
    //internal static List<string> LstIgnoredFolders() =>
    //[.. LstRepositoryIgnoredFolders
    //    .Concat(LstOtherIgnoredFolders)
    //    .Distinct()
    //];
}