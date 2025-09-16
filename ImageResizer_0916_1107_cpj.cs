// 代码生成时间: 2025-09-16 11:07:18
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageProcessing
{
    public class ImageResizer
    {
        // Specify the desired dimensions for resizing
        private const int NewWidth = 800;
        private const int NewHeight = 600;

        /// <summary>
        /// Resizes all images in a directory to the specified dimensions.
        /// </summary>
        /// <param name="sourceDirectory">Directory containing the images to resize.</param>
        /// <param name="destinationDirectory">Directory where resized images will be saved.</param>
        public static void ResizeImages(string sourceDirectory, string destinationDirectory)
        {
            if (!Directory.Exists(sourceDirectory))
            {
                throw new DirectoryNotFoundException("Source directory not found.");
            }

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            string[] files = Directory.GetFiles(sourceDirectory);
            foreach (string file in files)
            {
                try
                {
                    ResizeImage(file, destinationDirectory);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error resizing image {file}: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Resizes a single image and saves it to a destination directory.
        /// </summary>
        /// <param name="sourceFile">Path to the image file to resize.</param>
        /// <param name="destinationDirectory">Directory to save the resized image.</param>
        private static void ResizeImage(string sourceFile, string destinationDirectory)
        {
            using (Image image = Image.FromFile(sourceFile))
            {
                float ratio = (float)Math.Min(NewWidth / image.Width, NewHeight / image.Height);
                int newWidth = (int)(image.Width * ratio);
                int newHeight = (int)(image.Height * ratio);

                using (Bitmap newImage = new Bitmap(newWidth, newHeight))
                {
                    using (Graphics graphics = Graphics.FromImage(newImage))
                    {
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                        graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                    }

                    string fileName = Path.GetFileNameWithoutExtension(sourceFile) + "_resized" + Path.GetExtension(sourceFile);
                    string destinationFile = Path.Combine(destinationDirectory, fileName);
                    newImage.Save(destinationFile, image.RawFormat);
                }
            }
        }
    }
}
