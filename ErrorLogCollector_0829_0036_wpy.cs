// 代码生成时间: 2025-08-29 00:36:13
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLogging
{
    /// <summary>
    /// ErrorLogCollector class for collecting and logging application errors.
    /// </summary>
    public class ErrorLogCollector
    {
        private readonly string _logFilePath;

        /// <summary>
        /// Initializes a new instance of the ErrorLogCollector class.
        /// </summary>
        /// <param name="logFilePath">The path to the log file.</param>
        public ErrorLogCollector(string logFilePath)
        {
            _logFilePath = logFilePath ?? throw new ArgumentNullException(nameof(logFilePath));
        }

        /// <summary>
        /// Logs an error to the log file.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        public void LogError(string message)
        {
            try
            {
                // Ensure the directory exists
                var directory = Path.GetDirectoryName(_logFilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Write the error message to the log file
                File.AppendAllText(_logFilePath, message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during logging
                Console.WriteLine($"Error logging error: {ex.Message}");
            }
        }

        /// <summary>
        /// Asynchronously logs an error to the log file.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task LogErrorAsync(string message)
        {
            try
            {
                // Ensure the directory exists
                var directory = Path.GetDirectoryName(_logFilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    await Task.Run(() => Directory.CreateDirectory(directory));
                }

                // Write the error message to the log file asynchronously
                await File.AppendAllTextAsync(_logFilePath, message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during logging
                Console.WriteLine($"Error logging error: {ex.Message}");
            }
        }
    }
}
