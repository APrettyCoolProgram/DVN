// 261006_code
// 261006_documentation

namespace dvn.Core;

internal static class AppExtension
{
    internal static void Scoop()
    {
        Du.DuCmdExe.RunCommand("scoop update *", true);
    }
}
