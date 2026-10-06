// 261006_code
// 261006_documentation

using dvn.Core.Manifest;

namespace dvn.Core;

internal class DvnManifest
{
    /// <summary>The development environment definition.</summary>
    public DvnEnvironment DevelopmentEnvironment { get; set; }

    /// <summary>The applications associated with the environment.</summary>
    public List<_DvnApplication> EnvironmentApplications { get; set; }

    /// <summary>The web browser configuration for the environment.</summary>
    public _DvnWebBrowser WebBrowser { get; set; }

}
