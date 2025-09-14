// 代码生成时间: 2025-09-15 07:29:15
 * and is structured for maintainability and extensibility.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace FileBackupSyncTool
{
    public class FileBackupAndSyncTool
    {
        // The source directory to backup files from
        private readonly string sourceDirectory;
        // The destination directory to backup files to
        private readonly string destinationDirectory;

        public FileBackupAndSyncTool(string source, string destination)
        {
            sourceDirectory = source;
            destinationDirectory = destination;
        }

        // Backup files from the source directory to the destination directory
        public void BackupFiles()
        {
            try
            {
                // Check if the directories exist
                if (!Directory.Exists(sourceDirectory))
                {
                    throw new DirectoryNotFoundException($"Source directory not found: {sourceDirectory}");
                }
                if (!Directory.Exists(destinationDirectory))
                {
                    // Create the destination directory if it does not exist
                    Directory.CreateDirectory(destinationDirectory);
                }

                // Copy all files from source to destination
                foreach (var file in Directory.GetFiles(sourceDirectory))
                {
                    var fileName = Path.GetFileName(file);
                    var destinationFile = Path.Combine(destinationDirectory, fileName);
                    File.Copy(file, destinationFile, true); // Overwrite if file exists
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the backup process
                Console.WriteLine($"An error occurred during backup: {ex.Message}");
            }
        }

        // Synchronize files between the source and destination directory
        public void SyncFiles()
        {
            try
            {
                // Get all files in both directories
                var sourceFiles = new HashSet<string>(Directory.GetFiles(sourceDirectory), StringComparer.OrdinalIgnoreCase);
                var destinationFiles = new HashSet<string>(Directory.GetFiles(destinationDirectory), StringComparer.OrdinalIgnoreCase);

                // Find files that need to be added or removed
                foreach (var file in sourceFiles)
                {
                    if (!destinationFiles.Contains(file))
                    {
                        // File not found in destination, copy it over
                        var fileName = Path.GetFileName(file);
                        var destinationFile = Path.Combine(destinationDirectory, fileName);
                        File.Copy(file, destinationFile, true); // Overwrite if file exists
                    }
                }

                foreach (var file in destinationFiles)
                {
                    if (!sourceFiles.Contains(file))
                    {
                        // File not found in source, delete it from destination
                        File.Delete(file);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the sync process
                Console.WriteLine($"An error occurred during synchronization: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tool = new FileBackupAndSyncTool("C:\SourceDirectory", "C:\DestinationDirectory");
            tool.BackupFiles();
            tool.SyncFiles();
        }
    }
}