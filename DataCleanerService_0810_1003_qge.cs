// 代码生成时间: 2025-08-10 10:03:59
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

/// <summary>
/// A data cleaning and preprocessing service.
/// </summary>
public class DataCleanerService
{
    // Regular expression patterns for common data cleaning tasks.
    private readonly Dictionary<string, string> _cleaningPatterns = new Dictionary<string, string>
    {
        { "trim", "^\s+|\s+$" }, // Trims leading and trailing whitespace.
        { "removeNewlines", "[\r\
]+" }, // Removes newline characters.
        { "removeSpecialChars", "[^a-zA-Z0-9 ]" } // Removes special characters except alphanumeric and space.
    };

    /// <summary>
    /// Cleans a dataset based on specified patterns.
    /// </summary>
    /// <param name="data">The dataset to be cleaned.</param>
    /// <returns>The cleaned dataset.</returns>
    public List<string> CleanData(IEnumerable<string> data)
    {
        var cleanedData = new List<string>();

        // Iterate over each data item and apply cleaning patterns.
        foreach (var item in data)
        {
            string cleanedItem = item;
            foreach (var patternKey in _cleaningPatterns.Keys)
            {
                cleanedItem = ApplyPattern(cleanedItem, patternKey);
            }
            cleanedData.Add(cleanedItem);
        }

        return cleanedData;
    }

    /// <summary>
    /// Applies a specific cleaning pattern to a data item.
    /// </summary>
    /// <param name="dataItem">The data item to clean.</param>
    /// <param name="patternKey">The key of the pattern to apply.</param>
    /// <returns>The cleaned data item.</returns>
    private string ApplyPattern(string dataItem, string patternKey)
    {
        if (_cleaningPatterns.TryGetValue(patternKey, out var pattern))
        {
            return Regex.Replace(dataItem, pattern, "", RegexOptions.Compiled);
        }
        return dataItem;
    }
}
