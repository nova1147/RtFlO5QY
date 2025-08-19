// 代码生成时间: 2025-08-20 07:07:18
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace ImageProcessing
{
    // 图片尺寸批量调整器
    public class ImageResizer
    {
        private const string DefaultOutputPath = "./resized_images/";
        private const string DefaultInputPath = "./input_images/";
        private const string DefaultExtension = ".jpg";

        // 构造函数，设置输入输出路径
        public ImageResizer(string inputPath, string outputPath)
        {
            InputPath = inputPath;
            OutputPath = outputPath;
        }

        // 输入路径
        public string InputPath { get; private set; }

        // 输出路径
        public string OutputPath { get; private set; }

        // 调整图片尺寸
        public void ResizeImages(int width, int height)
        {
            // 确保输出目录存在
            Directory.CreateDirectory(OutputPath);

            try
            {
                foreach (var filename in Directory.GetFiles(InputPath, $"*.{DefaultExtension}"))
                {
                    using (Bitmap originalImage = new Bitmap(filename))
                    {
                        // 创建新的Bitmap对象
                        using (Bitmap resizedImage = new Bitmap(width, height))
                        {
                            using (Graphics graphics = Graphics.FromImage(resizedImage))
                            {
                                // 设置高质量插值法
                                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                // 设置高质量,低速度呈现平滑程度
                                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                // 清除整个绘图面并以透明背景色填充
                                graphics.Clear(Color.Transparent);
                                // 在指定位置并且按指定大小绘制原图
                                graphics.DrawImage(originalImage, 0, 0, width, height);
                                // 保存调整后的图片
                                resizedImage.Save(Path.Combine(OutputPath, Path.GetFileName(filename)), ImageFormat.Jpeg);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
