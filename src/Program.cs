// 261023_code
// 261023_documentation

using dvn.DvnApp;

namespace dvn;

/// <summary>Entry point for DVN.</summary>
internal static class Program
{
    /// <summary>Starts DVN with the provided command-line arguments.</summary>
    /// <param name="args">The command-line arguments passed to DVN.</param>
    internal static void Main(string[] args) => FlightPath.SpinUp(args);
}