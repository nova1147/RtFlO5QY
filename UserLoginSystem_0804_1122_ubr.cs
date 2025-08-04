// 代码生成时间: 2025-08-04 11:22:37
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// 简单的用户登录验证系统
[ApiController]
[Route("[controller]/[action]"])
public class UserLoginController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly Dictionary<string, string> _users = new Dictionary<string, string>()
    {
        // 存储用户名和密码的哈希值
        { "user1", "passwordHash1" },
        { "user2", "passwordHash2" }
    };

    public UserLoginController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            // 检查请求是否包含用户名和密码
            if (string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Username and password are required.");
            }

            // 检查用户名是否存在
            if (!_users.ContainsKey(loginRequest.Username))
            {
                return Unauthorized("Username not found.");
            }

            // 验证密码是否正确
            string passwordHash = _users[loginRequest.Username];
            if (!VerifyPasswordHash(loginRequest.Password, passwordHash))
            {
                return Unauthorized("Password is incorrect.");
            }

            // 登录成功，返回成功消息
            return Ok("Login successful.");
        }
        catch (Exception ex)
        {
            // 错误处理
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    // 密码哈希验证函数
    private bool VerifyPasswordHash(string password, string storedHash)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // 计算传入密码的哈希值
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            string passwordHash = builder.ToString();

            // 比较哈希值
            return storedHash.Equals(passwordHash);
        }
    }
}

// 登录请求的类
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
