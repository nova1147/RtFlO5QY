// 代码生成时间: 2025-09-13 11:50:10
using System;
using System.Collections.Generic;
using System.Linq;

// 数据统计分析器类
public class DataAnalyzer
{
    // 数据列表
    private List<double> dataList;

    // 构造函数
    public DataAnalyzer(List<double> dataList)
    {
        if (dataList == null)
            throw new ArgumentNullException(nameof(dataList));

        this.dataList = dataList;
    }

    // 计算平均值
    public double CalculateMean()
    {
        if (!dataList.Any())
            throw new InvalidOperationException("数据列表为空，无法计算平均值。");

        return dataList.Average();
    }

    // 计算中位数
    public double CalculateMedian()
    {
        if (!dataList.Any())
            throw new InvalidOperationException("数据列表为空，无法计算中位数。");

        var sortedList = dataList.OrderBy(x => x).ToList();
        int middle = sortedList.Count / 2;
        if (sortedList.Count % 2 == 0)
            return (sortedList[middle - 1] + sortedList[middle]) / 2;
        else
            return sortedList[middle];
    }

    // 计算最大值
    public double CalculateMax()
    {
        if (!dataList.Any())
            throw new InvalidOperationException("数据列表为空，无法计算最大值。");

        return dataList.Max();
    }

    // 计算最小值
    public double CalculateMin()
    {
        if (!dataList.Any())
            throw new InvalidOperationException("数据列表为空，无法计算最小值。");

        return dataList.Min();
    }
}

// 程序主类
class Program
{
    // 主函数
    static void Main(string[] args)
    {
        // 示例数据
        List<double> data = new List<double> { 1.5, 2.3, 3.7, 2.8, 4.1 };

        try
        {
            // 创建数据分析器实例
            DataAnalyzer analyzer = new DataAnalyzer(data);

            // 计算并输出平均值、中位数、最大值和最小值
            Console.WriteLine("平均值: " + analyzer.CalculateMean());
            Console.WriteLine("中位数: " + analyzer.CalculateMedian());
            Console.WriteLine("最大值: " + analyzer.CalculateMax());
            Console.WriteLine("最小值: " + analyzer.CalculateMin());
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine("发生错误: " + ex.Message);
        }
    }
}