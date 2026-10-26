// 261023_code
// 261026_documentation

namespace dvn.Extension;

/// <summary>The Scoop.sh extension for DVN.</summary>
internal class ScoopSh
{
    /// <summary>Indicates if Scoop integration is enabled.</summary>
    /// <value><see langword="true"/> when the application should use Scoop; otherwise, <see langword="false"/>.</value>
    public bool Enabled { get; set; }

    /// <summary>Indicates whether Scoop should be updated when DVN executes.</summary>
    /// <value><see langword="true"/> to trigger updating; otherwise, <see langword="false"/>.</value>
    public bool Update { get; set; }

    /// <summary>The ScoopSh update command string.</summary>
    /// <value>Default: <c>scoop update *</c></value>
    public string UpdateCmd { get; set; } = "scoop update *";

    /// <summary>Runs the configured Scoop update workflow when automatic updates are enabled.</summary>
    /// <param name="scoopSh">The configuration describing the current Scoop update behavior.</param>
    internal static void Roundhouse(ScoopSh scoopSh)
    {
        if (scoopSh.Update)
        {
            Console.WriteLine($"Updating Scoop...{Environment.NewLine}"); // TODO - UsrMsg

            ScoopShCommand(scoopSh.UpdateCmd);
        }
    }

    /// <summary>Executes a Scoop.sh command.</summary>
    /// <param name="cmd">The command string to execute.</param>
    private static void ScoopShCommand(string cmd)
    {
        Du.DuCmdExe.RunCommand(cmd, true);
    }
}