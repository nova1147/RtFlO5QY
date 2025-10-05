// 代码生成时间: 2025-10-05 23:57:47
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Microsoft.Extensions.Logging;

// 引入图像识别库Microsoft.ML
using Microsoft.ML;
using Microsoft.ML.Data;

// 定义模型数据结构
public class ImageData
{
    [LoadColumn(0)]
    public string ImagePath;

    [LoadColumn(1)]
    public bool IsCat;
}

// 定义预测结果数据结构
public class ImagePrediction
{
    [ColumnName("PredictedLabel")]
    public bool PredictedIsCat;
}

[ApiController]
[Route("api/[controller]/[action]"])
public class ImageRecognitionController : ControllerBase
{
    private readonly ILogger<ImageRecognitionController> _logger;
    private readonly ITransformer _model;

    public ImageRecognitionController(ILogger<ImageRecognitionController> logger, ITransformer model)
    {
        _logger = logger;
        _model = model;
    }

    // POST: api/ImageRecognition/RecognizeImage
    [HttpPost]
    public IActionResult RecognizeImage([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        try
        {
            // 确保文件类型符合要求
            if (Path.GetExtension(file.FileName).ToLower() != ".jpg" && Path.GetExtension(file.FileName).ToLower() != ".png")
            {
                return BadRequest("Unsupported file format. Only .jpg and .png are allowed.");
            }

            // 读取图像数据
            byte[] imageBytes = file.OpenReadStream().ReadBytes();
            string imagePath = "path_to_save_image/" + file.FileName;
            File.WriteAllBytes(imagePath, imageBytes);

            // 创建模型输入
            ImageData imageData = new ImageData() { ImagePath = imagePath };

            // 使用模型进行预测
            ImagePrediction prediction = _model.Transform(imageData).Predict<ImagePrediction>();

            // 返回预测结果
            return Ok(new { PredictedIsCat = prediction.PredictedIsCat });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred during image recognition.");
            return StatusCode(500, "Internal Server Error");
        }
    }
}
