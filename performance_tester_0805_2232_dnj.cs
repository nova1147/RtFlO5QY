// 代码生成时间: 2025-08-05 22:32:05
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PerformanceTestingApp
{
    // PerformanceTester类用于执行性能测试
    public class PerformanceTester
    {
        private readonly string _url;

        public PerformanceTester(string url)
        {
            _url = url;
        }

        // 执行性能测试的方法
        public async Task TestPerformanceAsync()
        {
            try
            {
                // 使用HttpClient进行HTTP请求
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    var watch = Stopwatch.StartNew();

                    // 发送GET请求
                    var response = await httpClient.GetAsync(_url);
                    response.EnsureSuccessStatusCode();

                    // 测量请求时间
                    watch.Stop();

                    Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            // 测试的URL
            string testUrl = "http://example.com";

            // 创建PerformanceTester实例
            var tester = new PerformanceTester(testUrl);

            // 执行性能测试
            await tester.TestPerformanceAsync();
        }
    }
}