// 代码生成时间: 2025-08-14 13:23:42
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ThemeSwitcherApp.Controllers
{
    /// <summary>
    /// Controller responsible for handling theme switching functionality.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class ThemeSwitcherController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor injection of IHttpContextAccessor.
        /// </summary>
        /// <param name="httpContextAccessor">Accessor for HTTP context.</param>
        public ThemeSwitcherController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// Switches the theme based on the theme name provided in the query string.
        /// </summary>
        /// <param name="themeName">The name of the theme to switch to.</param>
        /// <returns>A message indicating the theme has been switched.</returns>
        [HttpGet]
        public IActionResult SwitchTheme(string themeName)
        {
            if (string.IsNullOrEmpty(themeName))
            {
                return BadRequest("Theme name is required.");
            }

            var themes = new[] { "light", "dark", "colorful" };
            if (!themes.Contains(themeName.ToLowerInvariant()))
            {
                return BadRequest("Invalid theme name.");
            }

            // Set the theme in the user's session or cookie
            _httpContextAccessor.HttpContext.Response.Cookies.Append("theme", themeName, new CookieOptions { Expires = DateTime.UtcNow.AddDays(1) });

            return Ok($"Theme switched to {themeName}.");
        }
    }
}