// 261006_code
// 261006_documentation

namespace dvn.Core;

/// <summary>Extension logic.</summary>
internal static class AppExtension
{
    /// <summary>Scoop logic.</summary>
    internal static void Scoop()
    {
        Du.DuCmdExe.RunCommand("scoop update *", true);
    }
}
