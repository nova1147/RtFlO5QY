// 代码生成时间: 2025-08-13 17:52:08
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonDataConverterApp
{
    /// <summary>
    /// Provides functionality to convert JSON data into various formats.
    /// </summary>
    public class JsonDataConverter
    {
        /// <summary>
        /// Converts JSON string to an object of a specified type.
        /// </summary>
        /// <typeparam name="T">The type of the object to convert to.</typeparam>
        /// <param name="json">The JSON string to convert.</param>
        /// <param name="options">JSON serializer options.</param>
        /// <returns>The object of type T.</returns>
        public static T ConvertFromJson<T>(string json, JsonSerializerOptions options = null)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException(nameof(json), "The JSON string cannot be null or empty.");
            }

            try
            {
                return JsonSerializer.Deserialize<T>(json, options);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to deserialize JSON.", ex);
            }
        }

        /// <summary>
        /// Converts an object to a JSON string.
        /// </summary>
        /// <param name="obj">The object to convert.</param>
        /// <param name="options">JSON serializer options.</param>
        /// <returns>The JSON string representation of the object.</returns>
        public static string ConvertToJson(object obj, JsonSerializerOptions options = null)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "The object to serialize cannot be null.");
            }

            try
            {
                return JsonSerializer.Serialize(obj, options);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to serialize object to JSON.", ex);
            }
        }
    }
}
