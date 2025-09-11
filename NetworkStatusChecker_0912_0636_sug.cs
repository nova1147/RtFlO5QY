// 代码生成时间: 2025-09-12 06:36:41
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace NetworkStatusChecker
{
    /// <summary>
    /// A program to check the network connection status using C# and ASP.NET.
    /// </summary>
    public class NetworkStatusChecker
    {
        private readonly string _testUrl = "http://www.google.com"; // URL used to test internet connectivity

        /// <summary>
        /// Checks the network connection status.
        /// </summary>
        /// <returns>Returns a boolean indicating whether the network is connected or not.</returns>
        public async Task<bool> CheckNetworkConnectionAsync()
        {
            try
            {
                using (var client = new WebClient())
                {
                    // Using the HEAD method to check the connection without downloading any content
                    client.Headers.Add("User-Agent", "Mozilla/5.0");
                    await client.OpenReadTaskAsync(_testUrl);
                    return true; // Connection successful
                }
            }
            catch (WebException ex)
            {
                // Handle the exception, log it if needed
                Console.WriteLine($"Error checking network connection: {ex.Message}");
                return false; // Connection failed
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return false; // Connection failed
            }
        }

        /// <summary>
        /// Checks the network availability using Ping.
        /// </summary>
        /// <returns>Returns a boolean indicating whether the network is reachable or not.</returns>
        public bool CheckNetworkAvailability()
        {
            try
            {
                var ping = new Ping();
                PingReply reply = ping.Send(_testUrl.Split('/')[2]); // Ping the domain without protocol and subdomain
                return reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                return false; // Ping failed
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return false; // Ping failed
            }
        }
    }
}
