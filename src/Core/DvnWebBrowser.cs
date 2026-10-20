// 261020_code
// 261020_documentation

namespace dvn.Core;

internal class DvnWebBrowser
{
    /// <summary>A dictionary containing browser names and their associated pages.</summary>
    /// <remarks>
    ///     The keys are the browser names (for example, <c>IExplore</c> or <c>Firefox</c>), and the values are dictionaries
    ///     where the keys are page titles and the values are URLs.
    /// </remarks>
    public Dictionary<string, Dictionary<string, string>> BrowserPages { get; set; }

}
