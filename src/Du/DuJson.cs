// 261006_code
// 261006_documentation

using System.Text.Json;

namespace dvn.Du;

/// <summary>.NET 10 methods for working with JSON data.</summary>
public static class DuJson
{
    /// <summary>Option for pretty-printed JSON output.</summary>
    private static readonly JsonSerializerOptions s_pretty = new()
    {
        WriteIndented = true
    };

    /// <summary>Option for compact JSON output.</summary>
    private static readonly JsonSerializerOptions s_compact = new()
    {
        WriteIndented = false
    };

    // [261006]
    /// <summary>Exports a JSON object to a local file.</summary>
    /// <typeparam name="JsonObject">The type of the JSON object.</typeparam>
    /// <param name="jsonObject">The JSON object to export.</param>
    /// <param name="filePath">The file path to export the JSON object to.</param>
    /// <param name="prettyJson">Determines if the JSON data is formatted.</param>
    /// <example>
    /// <code language="c#">
    /// // Pretty
    /// Du.DuSystemTextJson.ExportLocalFile(myObject, @"C:\Path\to\file.json", true);
    /// // Compact
    /// Du.DuSystemTextJson.ExportLocalFile(myObject, @"C:\Path\to\file.json", false);
    /// </code>
    /// </example>
    public static void ExportLocalFile<JsonObject>(JsonObject jsonObject, string filePath, bool prettyJson = true)
    {
        var jsonFormat = prettyJson
            ? s_pretty
            : s_compact;

        var fileContent = JsonSerializer.Serialize(jsonObject, jsonFormat);

        File.WriteAllText(filePath, fileContent);
    }

    // [261006]
    /// <summary>Imports a JSON object from a local file.</summary>
    /// <typeparam name="JsonObject">The type of the JSON object.</typeparam>
    /// <param name="filePath">The file path to import the JSON object from.</param>
    /// <returns>The imported JSON object.</returns>
    /// <example>
    /// <code language="c#">
    /// var myObject = Du.DuSystemTextJson.ImportFromLocalFile&lt;MyObject&gt;(@"C:\Path\to\file.json");
    /// </code>
    /// </example>
    /// <exception cref="FileNotFoundException">The file does not exist.</exception>
    /// <exception cref="InvalidDataException">The file is empty, contains only whitespace, or does not contain a valid JSON data.</exception>
    public static JsonObject ImportLocalFile<JsonObject>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file '{filePath}' does not exist.");
        }

        var fileContents = File.ReadAllText(filePath);

        if (string.IsNullOrWhiteSpace(fileContents))
        {
            throw new InvalidDataException($"The file '{filePath}' is empty or contains only whitespace.");
        }

        var result = JsonSerializer.Deserialize<JsonObject>(fileContents);

        return result is null
            ? throw new InvalidDataException($"The file '{filePath}' does not contain a valid JSON representation of {typeof(JsonObject).FullName}.")
            : result;
    }
}