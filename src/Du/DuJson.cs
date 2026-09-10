// 250910_code
// 260910_documentation

using System.Text.Json;

namespace dvn.Du;

/// <summary>Utility methods for working with JSON data.</summary>
public static class DuJson
{
    // [260909]
    /// <summary>Exports a JSON object to a file.</summary>
    /// <typeparam name="JsonObject">The type of the JSON object.</typeparam>
    /// <param name="jsonObject">The JSON object to export.</param>
    /// <param name="filePath">The file path to export the JSON object to.</param>
    /// <param name="prettyJson">Determines if the JSON data is formatted.</param>
    /// <example>
    /// <code>
    /// var myObject = new MyObject();
    /// Du.DuJson.ExportToLocalFile&lt;MyObject&gt;(myObject, @"C:\Path\to\file.json");        // formatted
    /// Du.DuJson.ExportToLocalFile&lt;MyObject&gt;(myObject, @"C:\Path\to\file.json", false); // not formatted
    /// </code>
    /// </example>
    public static void ExportToLocalFile<JsonObject>(JsonObject jsonObject, string filePath, bool prettyJson = true)
    {
        // TODO - There is a better way to do this.
        var jsonFormat = prettyJson
                ? new JsonSerializerOptions { WriteIndented = true }
                : new JsonSerializerOptions { WriteIndented = false };

        var fileContent = JsonSerializer.Serialize(jsonObject, jsonFormat);

        File.WriteAllText(filePath, fileContent);
    }

    // [260909]
    /// <summary>Imports a JSON object from a file.</summary>
    /// <typeparam name="JsonObject">The type of the JSON object.</typeparam>
    /// <param name="filePath">The file path to import the JSON object from.</param>
    /// <returns>The imported JSON object.</returns>
    /// <example>
    /// <code>
    /// var myObject = Du.DuJson.ImportFromLocalFile&lt;MyObject&gt;(@"C:\Path\to\file.json");
    /// </code>
    /// </example>
    public static JsonObject ImportFromLocalFile<JsonObject>(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<JsonObject>(fileContents);
    }
}