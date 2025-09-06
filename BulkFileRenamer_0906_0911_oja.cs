// 代码生成时间: 2025-09-06 09:11:08
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BulkFileRenamerApp.Controllers
{
    // 控制器负责处理文件重命名的请求
    [ApiController]
    [Route("[controller]"])
    public class BulkFileRenamerController : ControllerBase
    {
        private const string LogPath = "./logs/rename-log.txt";
        private readonly ILogger _logger;

        public BulkFileRenamerController(ILogger<BulkFileRenamerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult RenameFiles([FromBody] List<FileRenameRequest> requests)
        {
            if (requests == null || !requests.Any())
            {
                return BadRequest("No file rename requests provided.");
            }

            try
            {
                foreach (var request in requests)
                {
                    // 确保旧文件路径存在
                    if (!File.Exists(request.OldFilePath))
                    {
                        _logger.LogInformation($"File not found: {request.OldFilePath}");
                        continue;
                    }

                    // 构建新文件路径
                    var newFilePath = Path.Combine(Path.GetDirectoryName(request.OldFilePath), request.NewFileName);

                    // 重命名文件
                    File.Move(request.OldFilePath, newFilePath);

                    _logger.LogInformation($"Renamed file from {request.OldFilePath} to {newFilePath}");
                }

                return Ok("All files have been renamed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while renaming files.");
                return StatusCode(500, "An error occurred while renaming files.");
            }
        }
    }

    public class FileRenameRequest
    {
        // 旧文件路径
        public string OldFilePath { get; set; }
        // 新文件名
        public string NewFileName { get; set; }
    }
}
