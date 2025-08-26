// 代码生成时间: 2025-08-27 03:31:11
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace UserPermissionManagement
{
    public class UserPermissionManagementController : ControllerBase
    {
        // Dictionary to simulate a database of user permissions for demonstration purposes
        private readonly Dictionary<string, List<string>> userPermissions = new Dictionary<string, List<string>>
        {
            { "user1", new List<string> { "read", "write" } },
            { "user2", new List<string> { "read" } }
        };

        // GET: /UserPermissionManagement/CheckPermission/{userId}/{permission}
        [HttpGet("CheckPermission/{userId}/{permission}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public IActionResult CheckPermission(string userId, string permission)
        {
            // Check if the user exists in the dictionary
            if (!userPermissions.ContainsKey(userId))
            {
                return Unauthorized($"User {userId} not found.");
            }

            // Check if the user has the specified permission
            if (userPermissions[userId].Contains(permission))
            {
                return Ok($"User {userId} has the {permission} permission.");
            }
            else
            {
                return Unauthorized($"User {userId} does not have the {permission} permission.");
            }
        }

        // POST: /UserPermissionManagement/AddPermission/{userId}/{permission}
        [HttpPost("AddPermission/{userId}/{permission}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult AddPermission(string userId, string permission)
        {
            // Check if the user exists in the dictionary
            if (!userPermissions.ContainsKey(userId))
            {
                return BadRequest($"User {userId} not found.");
            }

            // Add the permission to the user
            if (userPermissions[userId].Contains(permission))
            {
                return BadRequest($"User {userId} already has the {permission} permission.");
            }
            else
            {
                userPermissions[userId].Add(permission);
                return Ok($"Permission {permission} added to user {userId}.");
            }
        }

        // POST: /UserPermissionManagement/RemovePermission/{userId}/{permission}
        [HttpPost("RemovePermission/{userId}/{permission}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult RemovePermission(string userId, string permission)
        {
            // Check if the user exists in the dictionary
            if (!userPermissions.ContainsKey(userId))
            {
                return BadRequest($"User {userId} not found.");
            }

            // Remove the permission from the user
            if (userPermissions[userId].Contains(permission))
            {
                userPermissions[userId].Remove(permission);
                return Ok($"Permission {permission} removed from user {userId}.");
            }
            else
            {
                return BadRequest($"User {userId} does not have the {permission} permission to remove.");
            }
        }
    }
}