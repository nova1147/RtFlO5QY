// 代码生成时间: 2025-10-13 02:56:29
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
# 优化算法效率

namespace RpcFramework
{
    /// <summary>
    /// RPC Client: Handles remote method invocation.
# 添加错误处理
    /// </summary>
    public class RpcClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _serviceUrl;
# 改进用户体验

        /// <summary>
        /// Initializes a new instance of the RpcClient class.
        /// </summary>
# 扩展功能模块
        /// <param name="serviceUrl">The base URL of the RPC service.</param>
        public RpcClient(string serviceUrl)
        {
            _httpClient = new HttpClient();
            _serviceUrl = serviceUrl;
        }

        /// <summary>
        /// Invokes a remote method with the given parameters.
# NOTE: 重要实现细节
        /// </summary>
        /// <typeparam name="TResult">The type of the result to return.</typeparam>
        /// <param name="methodName">The name of the method to invoke.</param>
        /// <param name="parameters">The parameters to pass to the method.</param>
        /// <returns>The result of the remote method invocation.</returns>
        public async Task<TResult> InvokeAsync<TResult>(string methodName, object parameters)
        {
            try
            {
                var requestUrl = $