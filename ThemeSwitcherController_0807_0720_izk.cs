// 代码生成时间: 2025-08-07 07:20:53
// ThemeSwitcherController.cs
// This controller handles theme switching functionality in an ASP.NET application.
using Microsoft.AspNetCore.Mvc;
using System;

namespace ThemeSwitchingApp.Controllers
{
    public class ThemeSwitcherController : Controller
    {
        // GET: /ThemeSwitcher/Switch
        [HttpGet]
        public IActionResult Switch(string theme)
        {
            // Check if the theme is provided and not null or empty
            if (string.IsNullOrEmpty(theme))
            {
                // Return an error view if the theme parameter is missing
                return View("Error");
            }

            // Validate the theme to ensure it's one of the supported themes
            if (!IsSupportedTheme(theme))
            {
                // Return an error view if the theme is not supported
                return View("Error");
            }

            // Set the theme in the user's session
            Session["Theme"] = theme;

            // Redirect to the previous page or a default page
            return RedirectToAction("Index", "Home");
        }

        // Helper method to check if the theme is supported
        private bool IsSupportedTheme(string theme)
        {
            // Define the supported themes
            var supportedThemes = new[] { "Light", "Dark", "HighContrast" };

            // Check if the provided theme is in the list of supported themes
            return supportedThemes.Contains(theme, StringComparer.OrdinalIgnoreCase);
        }
    }
}
