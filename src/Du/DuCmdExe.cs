// 261006_code
// 261006_documentation

namespace dvn.Du;

public static class DuCmdExe
{
    public static void Run(string arguments, bool showOutputInNewWindow = false)
    {
        var commandArguments = showOutputInNewWindow
            ? "/k " + arguments + " & timeout /t 10 /nobreak & exit"
            : "/c " + arguments;

        using var process = new System.Diagnostics.Process
        {
            StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = commandArguments,
                UseShellExecute = showOutputInNewWindow,
                RedirectStandardOutput = !showOutputInNewWindow,
                RedirectStandardError = !showOutputInNewWindow,
                CreateNoWindow = false,
                WindowStyle = showOutputInNewWindow
                    ? System.Diagnostics.ProcessWindowStyle.Normal
                    : System.Diagnostics.ProcessWindowStyle.Hidden
            }
        };

        process.Start();

        if (showOutputInNewWindow)
        {
            process.WaitForExit();
            return;
        }

        var output = process.StandardOutput.ReadToEnd();
        var error = process.StandardError.ReadToEnd();

        process.WaitForExit();

        if (!string.IsNullOrWhiteSpace(output))
        {
            Console.WriteLine(output);
        }

        if (!string.IsNullOrWhiteSpace(error))
        {
            Console.Error.WriteLine(error);
        }
    }
}