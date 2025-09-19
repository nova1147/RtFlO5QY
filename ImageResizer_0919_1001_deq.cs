// 代码生成时间: 2025-09-19 10:01:06
using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;
using System.Linq;

namespace ImageProcessingApp
{
    /// <summary>
    /// Class responsible for resizing images.
    /// </summary>
    public class ImageResizer
    {
        private readonly string _sourceFolder;
        private readonly string _destinationFolder;
        private readonly int _width;
        private readonly int _height;

        /// <summary>
        /// Initializes a new instance of the ImageResizer class.
        /// </summary>
        /// <param name="sourceFolder">The folder containing the original images.</param>
        /// <param name="destinationFolder">The folder where resized images will be saved.</param>
        /// <param name="width">The desired width for the resized images.</param>
        /// <param name="height">The desired height for the resized images.</param>
        public ImageResizer(string sourceFolder, string destinationFolder, int width, int height)
        {
            _sourceFolder = sourceFolder;
            _destinationFolder = destinationFolder;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Resize all images in the source folder to the specified dimensions and save them in the destination folder.
        /// </summary>
        public void ResizeImages()
        {
            // Check if source and destination folders exist
            if (!Directory.Exists(_sourceFolder))
                throw new DirectoryNotFoundException($"The source folder {_sourceFolder} does not exist.");

            if (!Directory.Exists(_destinationFolder))
                Directory.CreateDirectory(_destinationFolder);

            // Get all image files in the source folder
            var files = Directory.GetFiles(_sourceFolder, "*.*", SearchOption.TopDirectoryOnly)
                .Where(f => new FileInfo(f).Length > 0) // Filter out empty files
                .ToList();

            foreach (var file in files)
            {
                try
                {
                    ResizeImage(file);
                }
                catch (Exception ex)
                {
                    // Handle exceptions for each image, logging the error and skipping the problematic image
                    Console.WriteLine($"An error occurred while processing {Path.GetFileName(file)}: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Resizes a single image to the specified dimensions and saves it in the destination folder.
        /// </summary>
        /// <param name="filePath">The path to the image file to resize.</param>
        private void ResizeImage(string filePath)
        {
            using (var image = Image.Load(filePath))
            {
                // Resize the image
                image.Mutate(x => x.Resize(_width, _height));

                // Set the destination file path
                var destinationPath = Path.Combine(_destinationFolder, Path.GetFileName(filePath));

                // Save the resized image
                image.SaveAsJpeg(destinationPath);
            }
        }
    }
}
