// 代码生成时间: 2025-09-23 00:58:28
using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

// 系统性能监控控制器
[ApiController]
[Route("[controller]/[action]"]
public class SystemPerformanceMonitorController : ControllerBase
{
    // 获取CPU使用率
    [HttpGet]
    public IActionResult GetCpuUsage()
    {
        try
        {
            float cpuUsage = GetCpuPercentage();
            return Ok(new { CpuUsage = cpuUsage });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Server error: " + ex.Message);
        }
    }

    // 获取内存使用情况
    [HttpGet]
    public IActionResult GetMemoryUsage()
    {
        try
        {
            PerformanceCounter memCounter = new PerformanceCounter("Memory", "Available MBytes");
            float availableMemory = memCounter.NextValue();
            return Ok(new { AvailableMemory = availableMemory });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Server error: " + ex.Message);
        }
    }

    // 获取磁盘使用情况
    [HttpGet]
    public IActionResult GetDiskUsage()
    {
        try
        {
            var drives = DriveInfo.GetDrives();
            var diskUsages = new List<dynamic>();
            foreach (var drive in drives)
            {
                diskUsages.Add(new {
                    DriveName = drive.Name,
                    AvailableFreeSpace = drive.AvailableFreeSpace,
                    TotalSize = drive.TotalSize
                });
            }
            return Ok(diskUsages);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Server error: " + ex.Message);
        }
    }

    // 辅助方法，获取CPU使用率百分比
    private float GetCpuPercentage()
    {
        float cpuUsage = 0;
        PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        cpuUsage = cpuCounter.NextValue();
        return cpuUsage;
    }
}
