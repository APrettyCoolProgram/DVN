// 261006_code
// 261006_documentation

using System.Diagnostics;

namespace dvn.Du;

public static class DuCmdExe
{
    // [261006]
    /// <summary>Runs a command in the Windows Command Prompt (cmd.exe).</summary>
    /// <param name="command">The command (including all arguments) to run.</param>
    /// <param name="showOutputWindow">Whether to show the output window.</param>
    /// <remarks>
    /// The <c>command</c> is the string you would type in a terminal, for example: <c>tree /f /a >files.txt</c>
    /// </remarks>
    /// <example>
    /// <code language="c#">
    /// // Don't show the output
    /// Run("tree /f /a >files.txt", false);
    /// // Show the output in a new window
    /// Run("tree /f /a >files.txt", true);
    /// </code>
    /// </example>
    public static void RunCommand(string command, bool showOutputWindow = false)
    {
        var cmdString = BuildCommandString(command, showOutputWindow);

        using Process process = CreateProcess(cmdString, showOutputWindow);

        process.Start();

        process.WaitForExit();

        if (!showOutputWindow)
        {
            OutputToConsole(process);
        }
    }

    // [261006]
    /// <summary>Builds the command string to be passed to cmd.exe.</summary>
    /// <param name="command">The command (including all arguments) to run.</param>
    /// <param name="showOutput">Whether to show the output window.</param>
    /// <returns>The command string to be passed to cmd.exe.</returns>
    private static string BuildCommandString(string command, bool showOutput) =>
        showOutput
            ? $"/k {command} & timeout /t 10 /nobreak & exit"
            : $"/c {command}";

    // [261006]
    /// <summary>Outputs the standard output and standard error of the process to the console. </summary>
    /// <param name="process">The process whose output and error streams will be read and written to the console.</param>
    private static void OutputToConsole(Process process)
    {
        var output = process.StandardOutput.ReadToEnd();
        var error  = process.StandardError.ReadToEnd();

        if (!string.IsNullOrWhiteSpace(output))
        {
            Console.WriteLine(output);
        }

        if (!string.IsNullOrWhiteSpace(error))
        {
            Console.Error.WriteLine(error);
        }
    }

    // [261006]
    /// <summary>Creates a new Process instance configured to run cmd.exe.</summary>
    /// <param name="commandString">The command string to be passed to cmd.exe.</param>
    /// <param name="showOutput">Whether to show the output window.</param>
    /// <returns>A new Process instance configured to run cmd.exe.</returns>
    private static Process CreateProcess(string commandString, bool showOutput) => new()
    {
        StartInfo = new ProcessStartInfo
        {
            FileName               = "cmd.exe",
            Arguments              = commandString,
            UseShellExecute        = showOutput,
            RedirectStandardOutput = !showOutput,
            RedirectStandardError  = !showOutput,
            CreateNoWindow         = false,
            WindowStyle            = showOutput ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden
        }
    };
}