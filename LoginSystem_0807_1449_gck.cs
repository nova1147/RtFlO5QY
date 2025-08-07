// 代码生成时间: 2025-08-07 14:49:34
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

// 定义用户模型
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}

// 定义用户验证服务
public class UserService
{
    private readonly List<User> _users = new List<User>
    {
        new User { Username = "admin", Password = "password123" }
    };

    // 验证用户登录信息
    public bool ValidateUser(string username, string password)
    {
        var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        return user != null;
    }
}

// 登录处理器
public class LoginHandler : AuthenticationHandler<CookieAuthenticationOptions>
{
    private readonly UserService _userService;

    public LoginHandler(IOptionsMonitor<CookieAuthenticationOptions> options,
                      UserService userService,
                      ILoggerFactory logger,
                      UrlEncoder encoder,
                      ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
        _userService = userService;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var username = Request.Form["username"];
        var password = Request.Form["password"];

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return AuthenticateResult.Fail("Username or password is empty.");
        }

        if (!_userService.ValidateUser(username, password))
        {
            return AuthenticateResult.Fail("Invalid username or password.");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties();
        authProperties.IsPersistent = true;

        var userPrincipal = new ClaimsPrincipal(claimsIdentity);

        Context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperties).Wait();

        return AuthenticateResult.Success(new AuthenticationTicket(userPrincipal, CookieAuthenticationDefaults.AuthenticationScheme));
    }
}

// 启动配置
public static class LoginStartup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }).AddCookie();

        services.AddSingleton<UserService>();
        services.AddTransient<LoginHandler>();
    }

    public static void Configure(IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
