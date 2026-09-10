// 260910_code
// 260617_documentation

namespace dvn.Core.Resources;

/// <summary>Provides predefined data structures.</summary>
internal static class Catalog
{
    /// <summary>A list of repository files that should be ignored when copying.</summary>
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

    /// <summary>A list of other files that should be ignored when copying.</summary>
    internal static List<string> LstOtherIgnoredFiles =>
        [
        ];

    /// <summary>A list of repository folders that should be ignored when copying.</summary>
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

    /// <summary>A list of other folders that should be ignored when copying.</summary>
    internal static List<string> LstOtherIgnoredolders =>
    [
    ];

    /// <summary>Combines the configured file ignore lists.</summary>
    /// <returns>A list of file names that should be ignored when copying.</returns>
    internal static List<string> LstIgnoredFiles() =>
    [.. LstRepositoryIgnoredFiles
        .Concat(LstOtherIgnoredFiles)
        .Distinct()
    ];

    /// <summary>Combines the configured folder ignore lists.</summary>
    /// <returns>A list of folder names that should be ignored when copying.</returns>
    internal static List<string> LstIgnoredFolders() =>
    [.. LstRepositoryIgnoredFolders
        .Concat(LstOtherIgnoredolders)
        .Distinct()
    ];
}