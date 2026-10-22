// 261022_code
// 261022_documentation

using System.Reflection;

namespace dvn.Core.Resources;

/// <summary>Provides predefined user messages.</summary>
/// <remarks>
/// The <see cref="UsrMsg"/> class contains predefined user messages that are used throughout the source code, providing
/// a centralized location for commonly used data, and allowing easy access and modification.
/// </remarks>
internal static class UsrMsg
{
    /// <summary>The message that is displayed when DVN starts.</summary>
    /// <returns>The DVN start message.</returns>
    internal static string MsgStart =>
    """
    -=| DVN |=-

    """;

    /// <summary>The message displayed when command-line arguments are missing.</summary>
    /// <returns>The missing arguments message.</returns>
    internal static string MsgMissingArguments =>
    $"""
        ERROR: Missing arguments.

        Please type "dvn help" for more information.
        {MsgExit()}
     """;

    /// <summary>The message displayed when creating a new DVN configuration file.</summary>
    /// <returns>The new configuration file message.</returns>
    public static string MsgCreateConfig() =>
    $"""
        The DVN configuration file did not exist.

        A default configuration file was created.

     """;

    /// <summary>The help message.</summary>
    public static string MsgHelp =>
    $"""
     Usage:

       dvn <command> [-option(s)]

     Commands:

       %env%    Start an existing development environment
       about    Display information about DVN
       help     Display the DVN help screen
       list     Display a list of available development environments
       new      Create an empty manifest file

     Options:

       -b    Force data backup

     Examples:

       dvn list            Display a list of available development environments
       dvn MyProject -b    Start the MyProject environment and force a data backup

     For more information, please refer to the documentation:
     https://github.com/APrettyCoolProgram/DVN
     {MsgExit()}
     """;

    /// <summary>The about message.</summary>
    public static string MsgAbout =>
    $"""
    DVN is a command line utility for managing development environments.

    Version {Assembly.GetExecutingAssembly().GetName().Version}

    Repository: https://github.com/APrettyCoolProgram/dvn

    Manual: https://github.com/APrettyCoolProgram/DVN/tree/main/docs/man

    Copyright © 2026 A Pretty Cool Program
    Distributed under the Apache 2.0 License
    {MsgExit()}
    """;

    /// <summary>The message displayed when DNV exits.</summary>
    /// <param name="exitMessage">A customizable exit message.</param>
    /// <example>
    /// <code language="csharp">
    /// // This will return the default "Exiting DVN..." message
    /// var customMessage = MsgExit();
    /// // This will return a custom "Bye-bye for now!" message
    /// var customMessage = MsgExit("Bye-bye for now!");
    /// </code>
    /// </example>
    /// <returns>The DVN exit message.</returns>
    internal static string MsgExit(string exitMessage = "Exiting DVN...") =>
    $"""

     {exitMessage}

     """;

    // TODO pass extension
    /// <summary>The message displayed when creating a new DVN manifest.</summary>
    /// <param name="environmentName">The name of the environment.</param>
    /// <returns>The new manifest message.</returns>
    public static string MsgCreateManifest(string environmentName) =>
    $"""
     The "{environmentName}.dvn" manifest file was created.

     This file must be edited manually.

     For more information, please refer to the documentation:
         https://github.com/APrettyCoolProgram/DVN
     {MsgExit()}
     """;

    /// <summary>The message that displays the list of available environments.</summary>
    /// <param name="environmentList">The list of available environments.</param>
    /// <returns>The available environments message.</returns>
    public static string MsgEnvironmentList(string environmentList) =>
       $"""
        The following development environments are available:

        {environmentList}
        {MsgExit()}
        """;
}