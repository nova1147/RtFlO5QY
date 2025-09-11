// 代码生成时间: 2025-09-11 15:36:53
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

// 表单数据验证器
public class FormValidator
{
    // 验证表单数据的方法
    public bool Validate(object formObject)
    {
        // 获取表单对象的所有属性
        var properties = formObject.GetType().GetProperties();

        // 检查所有属性是否通过数据注解验证
        foreach (var property in properties)
        {
            // 获取属性值
            var value = property.GetValue(formObject);

            // 获取所有数据注解
            var validationAttributes = property.GetCustomAttributes<ValidationAttribute>();

            // 检查是否有数据注解
            if (validationAttributes.Any())
            {
                // 创建验证上下文
                var context = new ValidationContext(formObject, serviceProvider: null, items: null)
                {
                    DisplayName = property.Name
                };

                // 尝试验证属性值
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateProperty(value, context, results))
                {
                    // 如果验证失败，返回false
                    return false;
                }
            }
        }

        // 如果所有属性都通过验证，返回true
        return true;
    }
}

// 示例表单类
public class SampleForm
{
    [Required(ErrorMessage = "姓名不能为空")]
    public string Name { get; set; }

    [Required(ErrorMessage = "年龄不能为空")]
    [Range(18, 60, ErrorMessage = "年龄必须在18到60之间")]
    public int Age { get; set; }

    [EmailAddress(ErrorMessage = "邮箱地址无效")]
    public string Email { get; set; }
}

// 使用示例
class Program
{
    static void Main()
    {
        // 创建表单验证器实例
        var validator = new FormValidator();

        // 创建表单对象
        var form = new SampleForm
        {
            Name = "张三",
            Age = 25,
            Email = "zhangsan@example.com"
        };

        // 验证表单数据
        bool isValid = validator.Validate(form);

        if (isValid)
        {
            Console.WriteLine("表单数据验证通过");
        }
        else
        {
            Console.WriteLine("表单数据验证失败");
        }
    }
}