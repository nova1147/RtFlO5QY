// 代码生成时间: 2025-09-03 11:08:51
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// 权限管理控制器
[ApiController]
[Route("[controller]/[action]")]
public class UserPermissionController : ControllerBase
{
    private readonly IUserPermissionService _userPermissionService;

    // 注入用户权限服务
    public UserPermissionController(IUserPermissionService userPermissionService)
    {
        _userPermissionService = userPermissionService;
    }

    // 获取用户权限列表
    [HttpGet]
    public IActionResult GetUserPermissions(int userId)
    {
        try
        {
            var permissions = _userPermissionService.GetUserPermissions(userId);
            return Ok(permissions);
        }
        catch (Exception ex)
        {
            // 错误处理
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    // 添加用户权限
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult AddUserPermission([FromBody] UserPermissionModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userPermissionService.AddUserPermission(model);
            return Ok();
        }
        catch (Exception ex)
        {
            // 错误处理
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    // 删除用户权限
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteUserPermission(int userId, string permission)
    {
        try
        {
            _userPermissionService.DeleteUserPermission(userId, permission);
            return Ok();
        }
        catch (Exception ex)
        {
            // 错误处理
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
}

// 用户权限模型
public class UserPermissionModel
{
    public int UserId { get; set; }
    public string Permission { get; set; }
}

// 用户权限服务接口
public interface IUserPermissionService
{
    IEnumerable<string> GetUserPermissions(int userId);
    void AddUserPermission(UserPermissionModel model);
    void DeleteUserPermission(int userId, string permission);
}

// 用户权限服务实现
public class UserPermissionService : IUserPermissionService
{
    private readonly IUserRepository _userRepository;

    // 注入用户仓库
    public UserPermissionService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<string> GetUserPermissions(int userId)
    {
        var user = _userRepository.GetUser(userId);
        return user.Permissions;
    }

    public void AddUserPermission(UserPermissionModel model)
    {
        var user = _userRepository.GetUser(model.UserId);
        user.Permissions.Add(model.Permission);
        _userRepository.UpdateUser(user);
    }

    public void DeleteUserPermission(int userId, string permission)
    {
        var user = _userRepository.GetUser(userId);
        user.Permissions.Remove(permission);
        _userRepository.UpdateUser(user);
    }
}

// 用户仓库接口
public interface IUserRepository
{
    User GetUser(int userId);
    void UpdateUser(User user);
}

// 用户类
public class User
{
    public int UserId { get; set; }
    public List<string> Permissions { get; set; }
}
