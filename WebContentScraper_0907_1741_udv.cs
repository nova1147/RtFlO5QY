// 代码生成时间: 2025-09-07 17:41:34
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace WebScraper
{
    /// <summary>
    /// A class to scrape web content.
    /// </summary>
    public class WebContentScraper
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebContentScraper"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL to scrape from.</param>
        public WebContentScraper(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// Scrapes all text content from the specified URL.
        /// </summary>
        /// <param name="url">The URL to scrape.</param>
        /// <returns>A string containing the scraped content.</returns>
        public async Task<string> ScrapeTextContentAsync(string url)
        {
            try
            {
                var content = await FetchHtmlAsync(url);
                if (!string.IsNullOrEmpty(content))
                {
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(content);
                    return htmlDoc.DocumentNode.InnerText;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request exception: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            return null;
        }

        /// <summary>
        /// Fetches the HTML content from the specified URL.
        /// </summary>
        /// <param name="url">The URL to fetch from.</param>
        /// <returns>The HTML content as a string.</returns>
        private async Task<string> FetchHtmlAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
