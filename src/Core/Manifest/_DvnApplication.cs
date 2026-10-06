// 260917_code
// 260917_documentation

using System.Diagnostics;

namespace dvn.Core.Manifest;

/// <summary>Represents an application defined in a dvn manifest.</summary>
internal class _DvnApplication
{
    /// <summary>The application name.</summary>
    public string Name { get; set; }

    /// <summary>The application description.</summary>
    public string Description { get; set; }

    /// <summary>The application file name.</summary>
    public string FileName { get; set; }

    /// <summary>The application arguments.</summary>
    public string Arguments { get; set; }

    /// <summary>The working directory for the application.</summary>
    public string WorkingDirectory { get; set; }

    /// <summary>Starts each application in the supplied list.</summary>
    /// <remarks>Currently this functionality only works on Windows systems.</remarks>
    /// <param name="applications">A list of <see cref="_DvnApplication"/> instances.</param>
    internal static void StartApplications(List<_DvnApplication> applications)
    {
        foreach (_DvnApplication app in applications)
        {
            if (string.IsNullOrEmpty(app.FileName))
            {
                Console.WriteLine($"  No applications found.");

            }
            else
            {
                Console.WriteLine($"  Starting application: {app.Name}");

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName         = app.FileName,
                        Arguments        = app.Arguments,
                        WorkingDirectory = app.WorkingDirectory,
                        UseShellExecute  = true,
                        CreateNoWindow   = false
                    }
                };

                _=process.Start();
            }
        }
    }
}