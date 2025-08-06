// 代码生成时间: 2025-08-06 15:56:01
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace WebContentScraper
{
    // 网页内容抓取工具类
    public class WebContentScraper
    {
        private readonly HttpClient _httpClient;

        public WebContentScraper()
        {
            // 初始化HttpClient
            _httpClient = new HttpClient();
        }

        // 抓取网页内容的方法
        public async Task<string> FetchWebContentAsync(string url)
        {
            try
            {
                // 发送HTTP请求
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // 返回网页内容
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                // 异常处理：网络请求失败
                Console.WriteLine($"Error fetching web content: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                // 异常处理：其他错误
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        // 解析网页内容，提取特定标签内容的方法（示例：提取所有段落文本）
        public string ExtractParagraphs(string htmlContent)
        {
            // 使用正则表达式提取所有<p>标签内容
            string pattern = "<p[^>]*>(.*?)</p>",
                matches = Regex.Matches(htmlContent, pattern, RegexOptions.Singleline).Value;

            // 创建StringBuilder用于存储提取的段落文本
            StringBuilder paragraphs = new StringBuilder();

            // 遍历所有匹配项，提取段落内容
            foreach (Match match in matches)
            {
                paragraphs.AppendLine(match.Groups[1].Value.Trim());
            }

            // 返回提取的段落文本
            return paragraphs.ToString();
        }

        // 主程序入口
        public static async Task Main(string[] args)
        {
            // 创建WebContentScraper实例
            WebContentScraper scraper = new WebContentScraper();

            // 指定要抓取的网页URL
            string url = "https://example.com";

            // 抓取网页内容
            string content = await scraper.FetchWebContentAsync(url);

            // 如果内容非空，则提取段落文本
            if (content != null)
            {
                string paragraphs = scraper.ExtractParagraphs(content);

                // 将提取的段落文本保存到文件
                File.WriteAllText("extracted_paragraphs.txt", paragraphs);
            }
        }
    }
}