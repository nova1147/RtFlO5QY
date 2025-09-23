// 代码生成时间: 2025-09-23 19:05:45
using System;
using System.Collections.Generic;
using System.Linq;

// 命名空间 DataPreprocessing
namespace DataPreprocessing
{
    // 数据清洗和预处理工具类
    public class DataCleanerPreprocessor
    {
        // 清洗数据的方法
        public List<string> CleanData(List<string> rawData)
        {
            // 检查输入是否为null
            if (rawData == null)
                throw new ArgumentNullException(nameof(rawData));

            // 过滤空值
            var cleanedData = rawData.Where(item => !string.IsNullOrWhiteSpace(item)).ToList();

            // 返回清洗后的数据
            return cleanedData;
        }

        // 预处理数据的方法
        public List<string> PreprocessData(List<string> cleanedData)
        {
            // 检查输入是否为null
            if (cleanedData == null)
                throw new ArgumentNullException(nameof(cleanedData));

            // 转换所有数据为小写
            var preprocessedData = cleanedData.Select(item => item.ToLower()).ToList();

            // 返回预处理后的数据
            return preprocessedData;
        }
    }
}
