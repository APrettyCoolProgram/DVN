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
}