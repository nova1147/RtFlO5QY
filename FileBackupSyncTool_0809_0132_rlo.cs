// 代码生成时间: 2025-08-09 01:32:23
using System;
using System.IO;
using System.Collections.Generic;

namespace FileBackupSyncTool
{
    public class FileBackupSyncTool
    {
        // 备份文件到指定位置
        public void BackupFile(string sourcePath, string backupPath)
        {
            try
            {
                // 检查源文件是否存在
                if (!File.Exists(sourcePath))
                {
                    throw new FileNotFoundException("源文件不存在", sourcePath);
                }

                // 创建备份目录
                Directory.CreateDirectory(Path.GetDirectoryName(backupPath));

                // 复制文件到备份目录
                File.Copy(sourcePath, backupPath, true);

                Console.WriteLine($"文件 {sourcePath} 已备份到 {backupPath}
