// 260910_code
// 260617_documentation

using System.Reflection;

namespace dvn.Core.Resources;

/// <summary>Provides predefined user messages.</summary>
internal static class UsrMsg
{
    /// <summary>The DVN start message.</summary>
    internal static string MsgStartDvn =
    $"""
       ================
         DVN v{Assembly.GetExecutingAssembly().GetName().Version}
       ================

    """;

    /// <summary>The message displayed when DVN is executed for the first time.</summary>
    internal static string MsgWelcomeToDvn =
    $"""
        The DVN framework has been created.

        Type "dvn help" to get started.
        
        For more information, please refer to the documentation:
        https://github.com/APrettyCoolProgram/DVN
        {MsgExitDvn()}
     """;

    /// <summary>The message displayed when command-line arguments are missing.</summary>
    internal static string MsgMissingArguments =>
    $"""
        ERROR: Missing arguments.
        {MsgExitDvn()}
     """;

    /// <summary>The exit message template for DVN.</summary>
    /// <param name="exitMessage">A customizable exit message.</param>
    /// <returns>The formatted exit message.</returns>
    internal static string MsgExitDvn(string exitMessage = "Exiting DVN...") =>
    $"""

        {exitMessage}
     """;

    // TODO pass extension
    /// <summary>The message displayed when creating a new DVN manifest.</summary>
    /// <param name="environmentName">The name of the environment.</param>
    /// <returns>The new manifest message.</returns>
    public static string MsgCreateManifest(string environmentName) =>
    $"""
        ".dvn/manifest/{environmentName}.dvn" was created, and must be edited manually.

        For more information, please refer to the documentation:
        https://github.com/APrettyCoolProgram/DVN
        {MsgExitDvn()}
     """;

    /// <summary>The help message.</summary>
    public static string MsgHelp =>
    $"""
        --------
          HELP
        --------

        Usage: dvn <command> [-options]

        Commands:

          %environment%   Start/create a development environment manifest
          help            Display the dvn help screen
          about           Display information about dvn
          list            Display the available development environments

        Options:

          -b              Force data backups

        Examples:

          To list the available environments:

              "dvn list"

          To start a specific environment:

              "dvn %manifest% -b"

        For more information, please refer to the documentation:
        https://github.com/APrettyCoolProgram/DVN
        {MsgExitDvn()}
     """;

    /// <summary>The about message.</summary>
    public static string MsgAbout =>
       $"""
           ---------
             ABOUT
           ---------

           DVN is a command line utility for managing development environments.

           Repository:
           https://github.com/APrettyCoolProgram/dvn

           Manual:
           https://github.com/APrettyCoolProgram/DVN/tree/main/docs/man

           Copyright © 2026 A Pretty Cool Program
           Distributed under the Apache 2.0 License
           {MsgExitDvn()}
        """;

    /// <summary>The message that displays the list of available environments.</summary>
    /// <param name="environmentList">The list of available environments.</param>
    /// <returns>The available environments message.</returns>
    public static string msg_EnvList(string environmentList) =>
       $"""
           ----------------
             Environments
           ----------------

           {environmentList}
           {MsgExitDvn()}
        """;
}