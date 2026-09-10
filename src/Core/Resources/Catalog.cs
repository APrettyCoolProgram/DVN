// 260910_code
// 260910_documentation

namespace dvn.Core.Resources;

/// <summary>Provides predefined data structures.</summary>
internal static class Catalog
{
    /// <summary>Repository files that should not be backed up.</summary>
    internal static List<string> LstRepositoryIgnoredFiles =>
    [
        ".DS_Store",
        "Thumbs.db",
        "desktop.ini",
        "package-lock.json",
        "yarn.lock",
        "pnpm-lock.yaml",
        "npm-shrinkwrap.json"
    ];

    /// <summary>Other files that should not be backed up.</summary>
    internal static List<string> LstOtherIgnoredFiles =>
    [
    ];

    /// <summary>Repository folders that should not be backed up.</summary>
    internal static List<string> LstRepositoryIgnoredFolders =>
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

    /// <summary>Other folders that should not be backed up.</summary>
    internal static List<string> LstOtherIgnoredFolders =>
    [
    ];

    /// <summary>Combines the configured file ignore lists.</summary>
    /// <remarks>This is the list that is stored in the dvn.config file.</remarks>
    /// <returns>A list of file names that should be ignored when copying.</returns>
    internal static List<string> LstIgnoredFiles() =>
    [.. LstRepositoryIgnoredFiles
        .Concat(LstOtherIgnoredFiles)
        .Distinct()
    ];

    /// <summary>Combines the configured folder ignore lists.</summary>
    /// <remarks>This is the list that is stored in the dvn.config file.</remarks>
    /// <returns>A list of folder names that should be ignored when copying.</returns>
    internal static List<string> LstIgnoredFolders() =>
    [.. LstRepositoryIgnoredFolders
        .Concat(LstOtherIgnoredFolders)
        .Distinct()
    ];
}