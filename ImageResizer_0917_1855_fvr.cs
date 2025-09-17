// 代码生成时间: 2025-09-17 18:55:30
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;

namespace ImageProcessingApp
{
    /// <summary>
    /// Provides functionality to resize images in batch.
    /// </summary>
    public class ImageResizer
    {
        private readonly string _sourceFolder;
        private readonly string _destinationFolder;
        private readonly int _targetWidth;
        private readonly int _targetHeight;

        /// <summary>
        /// Initializes a new instance of the ImageResizer class.
        /// </summary>
        /// <param name="sourceFolder">The folder containing the original images.</param>
        /// <param name="destinationFolder">The folder to store the resized images.</param>
        /// <param name="targetWidth">The desired width for the resized images.</param>
        /// <param name="targetHeight">The desired height for the resized images.</param>
        public ImageResizer(string sourceFolder, string destinationFolder, int targetWidth, int targetHeight)
        {
            _sourceFolder = sourceFolder;
            _destinationFolder = destinationFolder;
            _targetWidth = targetWidth;
            _targetHeight = targetHeight;
        }

        /// <summary>
        /// Resizes all images in the source folder and saves them to the destination folder.
        /// </summary>
        public void ResizeImages()
        {
            try
            {
                var files = Directory.GetFiles(_sourceFolder, "*.*", SearchOption.AllDirectories)
                                 .Where(file => IsImage(file));

                foreach (var file in files)
                {
                    ResizeImage(file, Path.Combine(_destinationFolder, Path.GetFileName(file)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error resizing images: " + ex.Message);
            }
        }

        /// <summary>
        /// Resizes a single image and saves it to a new path.
        /// </summary>
        /// <param name="originalImagePath">The path to the original image.</param>
        /// <param name="resizedImagePath">The path to save the resized image.</param>
        private void ResizeImage(string originalImagePath, string resizedImagePath)
        {
            using (var image = Image.FromFile(originalImagePath))
            {
                var ratio = FindRatio(image, _targetWidth, _targetHeight);

                int newWidth = (int)(image.Width * ratio);
                int newHeight = (int)(image.Height * ratio);

                using (var resizedImage = new Bitmap(newWidth, newHeight))
                {
                    using (var graphics = Graphics.FromImage(resizedImage))
                    {
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                    }

                    resizedImage.Save(resizedImagePath, ImageFormat.Jpeg);
                }
            }
        }

        /// <summary>
        /// Determines the scaling ratio to maintain the aspect ratio of the image.
        /// </summary>
        /// <param name="image">The original image.</param>
        /// <param name="targetWidth">The desired width.</param>
        /// <param name="targetHeight">The desired height.</param>
        /// <returns>The scaling ratio.</returns>
        private double FindRatio(Image image, double targetWidth, double targetHeight)
        {
            double ratioWidth = targetWidth / image.Width;
            double ratioHeight = targetHeight / image.Height;
            return Math.Min(ratioWidth, ratioHeight);
        }

        /// <summary>
        /// Checks if a file is an image based on its extension.
        /// </summary>
        /// <param name="file">The file path to check.</param>
        /// <returns>True if the file is an image, otherwise false.</returns>
        private bool IsImage(string file)
        {
            var imageExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            var extension = Path.GetExtension(file).ToLower();
            return imageExtensions.Contains(extension);
        }
    }
}
