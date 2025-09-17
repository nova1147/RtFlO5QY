// 代码生成时间: 2025-09-18 06:08:56
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace UserLoginSystem
{
    // This class handles the user login logic.
    public class UserLoginService
    {
        private readonly Dictionary<string, string> _userCredentials;

        // Constructor that initializes the user credentials.
        public UserLoginService(Dictionary<string, string> userCredentials)
        {
            _userCredentials = userCredentials;
        }

        // Method to validate user credentials.
        public async Task<bool> ValidateUserCredentialsAsync(string username, string password)
        {
            // Check if the provided credentials match the stored ones.
            if (_userCredentials.TryGetValue(username, out string storedPassword) && storedPassword == password)
            {
                // Password matches, create claims and sign in the user.
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(
                    new[] { new Claim(ClaimTypes.Name, username) },
                    CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddYears(1)
                };

                await HttpContext.Current.GetAuthentication()
                    .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);

                return true;
            }
            return false;
        }
    }

    // Middleware to handle the login request.
    public class UserLoginMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly UserLoginService _userLoginService;

        public UserLoginMiddleware(RequestDelegate next, UserLoginService userLoginService)
        {
            _next = next;
            _userLoginService = userLoginService;
        }

        public async Task Invoke(HttpContext context)
        {
            // Get the username and password from the request.
            var username = context.Request.Query["username"].ToString();
            var password = context.Request.Query["password"].ToString();

            try
            {
                // Validate the user credentials.
                var isValid = await _userLoginService.ValidateUserCredentialsAsync(username, password);

                if (isValid)
                {
                    // User is authenticated, proceed to the next middleware.
                    await _next(context);
                }
                else
                {
                    // Authentication failed, return an error.
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors.
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"An error occurred: {ex.Message}");
            }
        }
    }
}
