// 代码生成时间: 2025-10-07 03:17:23
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BackupRestoreUtility.Controllers
{
    /// <summary>
    /// Controller for handling backup and restore operations.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class BackupRestoreController : ControllerBase
    {
        private const string BackupDirectory = "./Backups";
        private const string BackupExtension = ".zip";

        /// <summary>
        /// Creates a backup of the specified directory.
        /// </summary>
        /// <param name="directoryPath">Path of the directory to backup.</param>
        /// <returns>A message indicating success or failure.</returns>
        [HttpGet]
        public IActionResult CreateBackup(string directoryPath)
        {
            try
            {
                if (string.IsNullOrEmpty(directoryPath))
                {
                    return BadRequest("Directory path cannot be empty.");
                }

                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                var backupPath = Path.Combine(BackupDirectory, $"backup-{timestamp}{BackupExtension}");
                ZipFile.CreateFromDirectory(directoryPath, backupPath);
                return Ok($"Backup created at: {backupPath}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating backup: {ex.Message}");
            }
        }

        /// <summary>
        /// Restores a backup to the specified directory.
        /// </summary>
        /// <param name="backupPath">Path of the backup file.</param>
        /// <param name="targetDirectory">Path of the directory to restore to.</param>
        /// <returns>A message indicating success or failure.</returns>
        [HttpGet]
        public IActionResult RestoreBackup(string backupPath, string targetDirectory)
        {
            try
            {
                if (string.IsNullOrEmpty(backupPath) || !File.Exists(backupPath))
                {
                    return BadRequest("Backup file does not exist.");
                }

                if (string.IsNullOrEmpty(targetDirectory))
                {
                    return BadRequest("Target directory cannot be empty.");
                }

                ZipFile.ExtractToDirectory(backupPath, targetDirectory);
                return Ok($"Restored backup to: {targetDirectory}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error restoring backup: {ex.Message}");
            }
        }
    }
}