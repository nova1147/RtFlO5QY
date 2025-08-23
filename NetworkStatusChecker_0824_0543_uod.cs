// 代码生成时间: 2025-08-24 05:43:12
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace NetworkChecker
{
    public class NetworkStatusChecker
    {
        // The server to ping
        private readonly string _pingAddress;

        // Constructor that takes the address of the server
        public NetworkStatusChecker(string pingAddress)
        {
            _pingAddress = pingAddress;
        }

        // Method to check the network status
        public async Task<bool> CheckNetworkStatusAsync()
        {
            try
            {
                // Create a new Ping instance
                using (Ping pingSender = new Ping())
                {
                    // Send an asynchronous ping to the address
                    PingReply reply = await pingSender.SendPingAsync(_pingAddress);

                    // Check the status of the reply
                    if (reply.Status == IPStatus.Success)
                    {
                        Console.WriteLine("Network is available. Ping successful.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Ping failed. Status: {reply.Status}");
                        return false;
                    }
                }
            }
            catch (PingException ex)
            {
                // Handle ping exceptions
                Console.WriteLine($"Ping failed with error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        // Main method for demonstration purposes
        public static async Task Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: NetworkStatusChecker <ping address>");
                return;
            }

            string pingAddress = args[0];
            NetworkStatusChecker checker = new NetworkStatusChecker(pingAddress);
            bool isNetworkAvailable = await checker.CheckNetworkStatusAsync();

            if (isNetworkAvailable)
            {
                Console.WriteLine("The network is available.");
            }
            else
            {
                Console.WriteLine("The network is not available.");
            }
        }
    }
}
