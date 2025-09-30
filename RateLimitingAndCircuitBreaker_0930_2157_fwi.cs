// 代码生成时间: 2025-09-30 21:57:07
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Polly;
using System.Net;
using System.Threading.Tasks;

namespace RateLimitingAndCircuitBreaker
{
    // 定义API限流器和熔断器的中间件
    public class RateLimitingCircuitBreakerMiddleware
    {
        private readonly RequestDelegate _next;

        // 构造函数，注入请求委托
        public RateLimitingCircuitBreakerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // 中间件处理请求的方法
        public async Task Invoke(HttpContext context)
        {
            // 定义限流策略
            var rateLimitingPolicy = PolicyExtensions
                .HandleResult<HttpContext>(r => r.Response.StatusCode == (int)HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5) });

            // 定义熔断器策略
            var circuitBreakerPolicy = Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(3, TimeSpan.FromMinutes(1));

            try
            {
                // 执行限流策略
                await rateLimitingPolicy.ExecuteAsync(async () =>
                {
                    // 执行熔断器策略
                    await circuitBreakerPolicy.ExecuteAsync(async () =>
                    {
                        await _next(context);
                    });
                });
            }
            catch (Exception ex)
            {
                // 错误处理，返回熔断器错误信息
                context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                await context.Response.WriteAsync("Service is currently unavailable. Please try again later.");
            }
        }
    }

    // 扩展类，用于添加中间件到请求管道
    public static class RateLimitingCircuitBreakerExtension
    {
        public static IApplicationBuilder UseRateLimitingCircuitBreaker(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RateLimitingCircuitBreakerMiddleware>();
        }
    }
}
