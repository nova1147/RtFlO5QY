// 代码生成时间: 2025-08-23 14:40:21
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace BatchFileRenamer
{
    // 批量文件重命名工具类
    public class BatchFileRenamer
    {
        private readonly string _sourceDirectory;
        private readonly string _destinationDirectory;

        // 初始化构造器
        public BatchFileRenamer(string sourceDirectory, string destinationDirectory)
        {
            _sourceDirectory = sourceDirectory;
            _destinationDirectory = destinationDirectory;
        }

        // 执行批量重命名操作
        public void RenameFiles()
        {
            // 检查源目录是否存在
            if (!Directory.Exists(_sourceDirectory))
            {
                throw new DirectoryNotFoundException($"源目录 {_sourceDirectory} 未找到。");
            }

            // 确保目标目录存在
            Directory.CreateDirectory(_destinationDirectory);

            // 获取所有文件
            var files = Directory.GetFiles(_sourceDirectory);

            foreach (var file in files)
            {
                try
                {
                    // 创建新的文件名
                    var fileName = Path.GetFileName(file);
                    var newFileName = $"{Path.GetFileNameWithoutExtension(file)}_{DateTime.Now:yyyyMMddHHmmss}_{Path.GetExtension(file)}";

                    // 构造目标文件路径
                    var destinationFile = Path.Combine(_destinationDirectory, newFileName);

                    // 重命名文件
                    File.Move(file, destinationFile);

                    Console.WriteLine($"文件 {fileName} 已重命名为 {newFileName}。");
                }
                catch (Exception ex)
                {
                    // 处理重命名过程中的异常
                    Console.WriteLine($"无法重命名文件 {file}: {ex.Message}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var sourceDirectory = @"C:\SourceFolder";
                var destinationDirectory = @"C:\DestinationFolder";

                // 创建批量文件重命名工具实例
                var renamer = new BatchFileRenamer(sourceDirectory, destinationDirectory);

                // 执行重命名操作
                renamer.RenameFiles();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"程序发生错误: {ex.Message}");
            }
        }
    }
}