// 261021_code
// 261005_documentation

using dvn.Core;

namespace dvn;

/// <summary>Entry point for DVN.</summary>
internal static class Program
{
    /// <summary>Starts DVN with the provided command-line arguments.</summary>
    /// <param name="passedArguments">The command-line arguments passed to DVN.</param>
    internal static void Main(string[] passedArguments) => AppState.SpinUp(passedArguments);
}