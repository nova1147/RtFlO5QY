// 代码生成时间: 2025-10-11 01:31:22
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SystemMonitor
{
    /// <summary>
    /// A class to monitor system performance metrics.
    /// </summary>
    public class PerformanceMonitor
    {
        private const int DefaultInterval = 1000; // Default interval in milliseconds

        /// <summary>
        /// Monitors the system performance metrics and logs them at the specified interval.
        /// </summary>
        /// <param name="interval">The interval at which to log the performance metrics.</param>
        public async Task StartMonitoring(int interval = DefaultInterval)
        {
            try
            {
                while (true)
                {
                    await LogPerformanceMetrics();
                    Thread.Sleep(interval);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Logs the current system performance metrics.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task LogPerformanceMetrics()
        {
            var timer = Stopwatch.StartNew();
            var cpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
            var memoryUsage = Process.GetCurrentProcess().WorkingSet64;

            // Simulate some work to demonstrate CPU usage
            await Task.Delay(100);

            cpuUsage = Process.GetCurrentProcess().TotalProcessorTime - cpuUsage;

            timer.Stop();

            Console.WriteLine($"CPU Usage: {cpuUsage / (timer.Elapsed.TotalMilliseconds * Environment.ProcessorCount):P2}, Memory Usage: {memoryUsage / (1024 * 1024)} MB");
        }
    }
}
