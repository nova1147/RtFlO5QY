// 代码生成时间: 2025-08-17 04:01:10
using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ErrorLogCollector
{
    /// <summary>
    /// ErrorLogCollector is a middleware that captures errors and logs them to a file.
    /// </summary>
    public class ErrorLogCollectorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorLogCollectorMiddleware> _logger;
        private readonly string _logFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorLogCollectorMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        /// <param name="logger">The logger instance.</param>
        /// <param name="logFilePath