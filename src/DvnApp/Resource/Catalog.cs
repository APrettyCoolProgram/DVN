// 261023_code
// 261023_documentation

namespace dvn.DvnApp.Resource;

/// <summary>Predefined resources and data structures.</summary>
/// <remarks>
/// The <see cref="Catalog"/> class contains predefined resources and data structures that are used throughout the
/// source code, providing a centralized location for commonly used data, and allowing easy access and modification.
/// </remarks>
internal static class Catalog
{
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