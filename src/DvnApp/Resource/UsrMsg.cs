// 261023_code
// 261023_documentation

using System.Reflection;

namespace dvn.DvnApp.Resource;

/// <summary>Provides predefined user messages.</summary>
/// <remarks>
/// The <see cref="UsrMsg"/> class contains predefined user messages that are used throughout the source code, providing
/// a centralized location for commonly used data, and allowing easy access and modification.
/// </remarks>
internal static class UsrMsg
{
    internal static string MsgStartDvn =>
    """
    -=| DVN |=-

    """;

    internal static string MsgMissingArgs =>
    $"""
     ERROR: Missing arguments.

     Please type "dvn help" for more information.
     {MsgExitDvn()}
     """;

    internal static string MsgCreateConfig =>
    """
    The DVN configuration file did not exist.

    A default configuration file was created.

    """;

    internal static string MsgDvnHelp =>
    $"""
     Usage:

       dvn <command> [-option(s)]

     Commands:

       %deven%    Start an existing development environment
       about      Display information about DVN
       help       Display the DVN help screen
       list       Display a list of available development environments
       new        Create an empty manifest file

     Options:

       -b    Force data backup

     Examples:

       dvn list            Display a list of available development environments
       dvn MyProject -b    Start the MyProject environment and force a data backup

     For more information, please refer to the documentation:
         https://github.com/APrettyCoolProgram/DVN
     {MsgExitDvn()}
     """;

    internal static string MsgAboutDvn =>
    $"""
    DVN is a command line utility for managing development environments.

    Version {Assembly.GetExecutingAssembly().GetName().Version}

    Repository: https://github.com/APrettyCoolProgram/DVN

    Manual: https://github.com/APrettyCoolProgram/DVN/tree/main/docs/man

    Copyright © 2026 A Pretty Cool Program
    Distributed under the Apache 2.0 License
    {MsgExitDvn()}
    """;

    internal static string MsgExitDvn(string msg = "Exiting DVN...") =>
    $"""

     {msg}

     """;

    internal static string MsgManifestNotFound(string manifestPath) =>
    $"""
     ERROR: Manifest file not found: {manifestPath.Replace(@".\", "")}

     {MsgExitDvn()}
     """;

    internal static string MsgCreateManifest(string deven) =>
    $"""
     The "{deven}.dvn" manifest file was created.

     This file must be edited manually.

     For more information, please refer to the documentation:
         https://github.com/APrettyCoolProgram/DVN
     {MsgExitDvn()}
     """;

    public static string MsgListDevens(string devens) =>
       $"""
        The following development environments are available:

        {devens}
        {MsgExitDvn()}
        """;
}