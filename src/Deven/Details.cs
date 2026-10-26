// 261026_code
// 261023_documentation

using dvn.Du;
using dvn.DvnApp;
using dvn.DvnApp.Resource;

namespace dvn.Deven;

internal class Details
{
    /// <summary>Displays a list of available environments to the console.</summary>
    internal static void DisplayDetails()
    {
        Dictionary<string, string> environmentDetails = GetDetails();

        if (environmentDetails.Count == 0)
        {
            FlightPath.SpinDown(UsrMsg.MsgListDevens("No environments found.")); // TODO - UsrMsg
        }
        else
        {
            Console.WriteLine(UsrMsg.MsgListDevens(DuDictionary.ConvertToString(environmentDetails, "  ", "")));
        }
    }

    /// <summary>Get environment details</summary>
    /// <returns>
    /// A dictionary containing environment names as keys and their descriptions as values.
    /// </returns>
    private static Dictionary<string, string> GetDetails()
    {
        var manifestFiles = Directory.GetFiles(".", "*.deven", SearchOption.TopDirectoryOnly);

        Dictionary<string, string> environmentDetails = [];

        foreach (var manifestFile in manifestFiles)
        {
            Manifest dvnManifest = DuJson.ImportLocalFile<Manifest>(manifestFile);

            environmentDetails[dvnManifest.Name] = dvnManifest.Description;
        }

        return environmentDetails;
    }
}
