// 代码生成时间: 2025-08-22 06:38:22
using System;
using System.IO;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Excel表格自动生成器
/// </summary>
public class ExcelGenerator
{
    /// <summary>
    /// 将数据生成Excel文件
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <param name="data">数据集合</param>
    /// <param name="filePath">文件路径</param>
    /// <param name="sheetName">工作表名称</param>
    public static void GenerateExcel<T>(IEnumerable<T> data, string filePath, string sheetName)
    {
        try
        {
            // 检查数据是否为空
            if (data == null || !data.Any())
            {
                throw new ArgumentException("数据集合不能为空");
            }

            // 使用EPPlus库创建Excel文件
            using (var package = new ExcelPackage())
            {
                // 添加一个工作表
                var worksheet = package.Workbook.Worksheets.Add(sheetName);

                // 将数据写入工作表
                int row = 1;
                foreach (T item in data)
                {
                    var properties = typeof(T).GetProperties();
                    for (int col = 1; col <= properties.Length; col++)
                    {
                        worksheet.Cells[row, col].Value = properties[col - 1].GetValue(item);
                    }
                    row++;
                }

                // 保存Excel文件
                FileInfo fileInfo = new FileInfo(filePath);
                if (!Directory.Exists(fileInfo.DirectoryName))
                {
                    Directory.CreateDirectory(fileInfo.DirectoryName);
                }
                package.SaveAs(new FileStream(filePath, FileMode.Create));
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine($"生成Excel文件时发生错误：{ex.Message}");
        }
    }

    /// <summary>
    /// 测试方法
    /// </summary>
    public static void Test()
    {
        // 测试数据
        List<TestData> testData = new List<TestData>()
        {
            new TestData { Name = "张三", Age = 18 },
            new TestData { Name = "李四", Age = 20 }
        };

        // 生成Excel文件
        GenerateExcel(testData, "Test.xlsx", "测试工作表");
    }
}

/// <summary>
/// 测试数据模型
/// </summary>
public class TestData
{
    public string Name { get; set; }
    public int Age { get; set; }
}