// 代码生成时间: 2025-10-11 17:18:54
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// 用于用户身份认证的控制器
[ApiController]
[Route("[api]/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    // 依赖注入IConfiguration接口用于读取配置文件
    public AuthenticationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
        try
        {
            // 验证用户凭据
            if (!await ValidateUserCredentials(userLoginDto))
            {
                return Unauthorized("Invalid username or password");
            }

            // 生成用户身份的JWT
            var token = GenerateJwtToken(userLoginDto.Username);
            return Ok(new { token });
        }
        catch (Exception ex)
        {
            // 错误处理
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    // 验证用户凭据的方法
    private async Task<bool> ValidateUserCredentials(UserLoginDto userLoginDto)
    {
        // 这里应该包含验证逻辑，如查询数据库验证用户名和密码
        // 此处省略具体实现，假设凭据总是有效
        return true;
    }

    // 生成JWT令牌的方法
    private string GenerateJwtToken(string username)
    {
        // 读取配置文件中的密钥
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // 创建claims
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // 创建tokenDescriptor
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = creds
        };

        // 生成token
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);

        return token;
    }
}

// 用户登录数据传输对象
public class UserLoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

// JWT配置的类
public static class JwtConfig
{
    public static readonly string SecretKey = "your_secret_key"; // 在实际应用中，这应该是一个安全存储的密钥
    public static readonly string Issuer = "your_app_issuer";
    public static readonly string Audience = "your_app_audience";
}

// 用于ASP.NET Core Startup类中配置JWT
public static class JwtSetup
{
    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = JwtConfig.Issuer,
                ValidateAudience = true,
                ValidAudience = JwtConfig.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });
    }
}
