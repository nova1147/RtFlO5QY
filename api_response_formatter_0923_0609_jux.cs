// 代码生成时间: 2025-09-23 06:09:52
using Microsoft.AspNetCore.Mvc;
# FIXME: 处理边界情况
using System;
using System.Collections.Generic;
using System.Net;
# TODO: 优化性能

namespace ApiResponseFormatter
# 改进用户体验
{
    /// <summary>
    /// A utility class to format API responses.
    /// </summary>
    public static class ApiResponseFormatter
    {
        /// <summary>
        /// Formats a successful API response.
# 改进用户体验
        /// </summary>
        /// <param name="data">The data to include in the response.</param>
        /// <returns>An OkObjectResult with the formatted response.</returns>
        public static IActionResult FormatSuccessResponse(object data)
        {
            var response = new
# 改进用户体验
            {
                success = true,
                data = data,
                message = "Operation successful."
            };
# 改进用户体验
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Formats an API response with an error.
        /// </summary>
        /// <param name="message">The error message to include in the response.</param>
        /// <param name="errorCode">The error code to include in the response.</param>
        /// <returns>A BadRequestObjectResult with the formatted response.</returns>
        public static IActionResult FormatErrorResponse(string message, int errorCode = 0)
        {
            var response = new
            {
                success = false,
                data = null,
                message = message,
                errorCode = errorCode
            };
            return new BadRequestObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }

        /// <summary>
        /// Formats an API response with an exception details.
        /// </summary>
        /// <param name="ex">The exception to include in the response.</param>
# 扩展功能模块
        /// <returns>A ObjectResult with the formatted response and 500 status code.</returns>
        public static IActionResult FormatExceptionResponse(Exception ex)
        {
            var response = new
            {
                success = false,
# 优化算法效率
                data = null,
                message = ex.Message,
                stackTrace = ex.StackTrace
            };
            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
# 添加错误处理
    }
}
