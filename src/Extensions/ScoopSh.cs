// 261022_code
// 261022_documentation

namespace dvn.Extensions;

/// <summary>The Scoop.sh extension for DVN.</summary>
internal class ScoopSh
{
    /// <summary>Indicates if Scoop integration is enabled.</summary>
    /// <value><see langword="true"/> when the application should use Scoop; otherwise, <see langword="false"/>.</value>
    public bool Enabled { get; set; }

    /// <summary>Indicates whether installed Scoop packages should be updated automatically.</summary>
    /// <value><see langword="true"/> to trigger automatic package updates; otherwise, <see langword="false"/>.</value>
    public bool AutoUpdate { get; set; }

    /// <summary>The command string executed by Scoop to update all components.</summary>
    /// <value><c>scoop update *</c></value>
    public string UpdateAllString { get; set; } = "scoop update *";

    /// <summary>Runs the configured Scoop update workflow when automatic updates are enabled.</summary>
    /// <param name="scoopSh">The configuration describing the current Scoop update behavior.</param>
    internal static void Roundhouse(ScoopSh scoopSh)
    {
        if (scoopSh.AutoUpdate)
        {
            ScoopShCommand(scoopSh.UpdateAllString);
        }
    }

    /// <summary>Executes a Scoop.sh command.</summary>
    /// <param name="commandString">The command string to execute.</param>
    private static void ScoopShCommand(string commandString)
    {
        Du.DuCmdExe.RunCommand(commandString, true);
    }
}