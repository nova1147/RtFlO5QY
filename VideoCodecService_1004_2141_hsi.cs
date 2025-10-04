// 代码生成时间: 2025-10-04 21:41:47
using System;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// VideoCodecService 负责视频编解码任务
public class VideoCodecService
{
    private readonly ILogger _logger;
    private const string FFMPEG_PATH = @"C:\path	o\ffmpeg.exe";

    // 构造函数注入ILogger
    public VideoCodecService(ILogger logger)
    {
        _logger = logger;
    }

    // 视频编码方法
    public ActionResult<string> EncodeVideo(string inputPath, string outputPath)
    {
        try
        {
            // 调用FFMPEG编码视频
            var command = $"-i {inputPath} -c:v libx264 -crf 28 {outputPath}";
            ExecuteFFMPEG(command);
            return Ok($"Video encoded successfully: {outputPath}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest($"Error encoding video: {ex.Message}");
        }
    }

    // 视频解码方法
    public ActionResult<string> DecodeVideo(string inputPath)
    {
        try
        {
            // 调用FFMPEG解码视频
            var command = $"-i {inputPath}";
            ExecuteFFMPEG(command);
            return Ok($"Video decoded successfully: {inputPath}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest($"Error decoding video: {ex.Message}");
        }
    }

    // 执行FFMPEG命令
    private void ExecuteFFMPEG(string command)
    {
        var startInfo = new ProcessStartInfo(FFMPEG_PATH)
        {
            Arguments = command,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = Process.Start(startInfo);
        process.WaitForExit();
    }
}
