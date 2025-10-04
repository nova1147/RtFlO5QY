// 代码生成时间: 2025-10-05 02:41:25
// DataMaskingTool.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataMaskingTool
{
    // 数据脱敏工具类
    public class DataMaskingTool
    {
        // 脱敏规则字典，键为数据类型，值为脱敏规则
        private Dictionary<string, Func<string, string>> maskingRules = new Dictionary<string, Func<string, string>>()
        {
            { "phone", MaskPhone },
            { "email", MaskEmail },
            { "address", MaskAddress }
        };

        // 脱敏数据
        public string MaskData(string data, string dataType)
        {
            // 检查是否包含脱敏规则
            if (maskingRules.ContainsKey(dataType))
            {
                // 应用脱敏规则
                return maskingRules[dataType](data);
            }
            else
            {
                // 如果没有找到对应的脱敏规则，抛出异常
                throw new ArgumentException("Unsupported data type for masking.");
            }
        }

        // 脱敏电话
        private string MaskPhone(string phone)
        {
            // 电话脱敏规则：保留前三位，其余替换为*
            return Regex.Replace(phone, "(\d{3})\d+", "$1***");
        }

        // 脱敏邮箱
        private string MaskEmail(string email)
        {
            // 邮箱脱敏规则：保留前两位和后两位，中间替换为*
            return Regex.Replace(email, "(\w{2})\w+(\w{2})", "$1***$2");
        }

        // 脱敏地址
        private string MaskAddress(string address)
        {
            // 地址脱敏规则：保留最后一级地址，其余替换为*
            var parts = address.Split(' ');
            if (parts.Length > 1)
            {
                return string.Join(" ", parts.Take(parts.Length - 1).Select(p => "*").Concat(new string[] { parts.Last() }));
            }
            else
            {
                return "*";
            }
        }
    }

    // 程序入口类
    class Program
    {
        static void Main(string[] args)
        {
            var dataMaskingTool = new DataMaskingTool();

            try
            {
                // 脱敏电话
                var maskedPhone = dataMaskingTool.MaskData("1234567890", "phone");
                Console.WriteLine($"Masked Phone: {maskedPhone}");

                // 脱敏邮箱
                var maskedEmail = dataMaskingTool.MaskData("example@example.com", "email");
                Console.WriteLine($"Masked Email: {maskedEmail}");

                // 脱敏地址
                var maskedAddress = dataMaskingTool.MaskData("123 Main St, Anytown, USA", "address");
                Console.WriteLine($"Masked Address: {maskedAddress}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
