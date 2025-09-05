// 代码生成时间: 2025-09-05 19:43:37
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 简单的库存管理系统
public class InventoryManagementSystem
{
    // 存储库存项的列表
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();

    // 构造函数
    public InventoryManagementSystem()
    {
    }

    // 添加库存项
    public void AddItem(string name, int quantity, decimal price)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Item name cannot be null or empty.");
        }
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero.");
        }
        if (price <= 0)
        {
            throw new ArgumentException("Price must be greater than zero.");
        }

        // 检查是否已存在同名商品
        var existingItem = inventoryItems.FirstOrDefault(i => i.Name == name);
        if (existingItem != null)
        {
            // 如果已存在，增加库存数量
            existingItem.Quantity += quantity;
        }
        else
        {
            // 如果不存在，添加新的库存项
            inventoryItems.Add(new InventoryItem { Name = name, Quantity = quantity, Price = price });
        }
    }

    // 删除库存项
    public void RemoveItem(string name)
    {
        var itemToRemove = inventoryItems.FirstOrDefault(i => i.Name == name);
        if (itemToRemove != null)
        {
            inventoryItems.Remove(itemToRemove);
        }
        else
        {
            throw new InvalidOperationException("Item not found in inventory.");
        }
    }

    // 更新库存数量
    public void UpdateQuantity(string name, int newQuantity)
    {
        var itemToUpdate = inventoryItems.FirstOrDefault(i => i.Name == name);
        if (itemToUpdate != null)
        {
            itemToUpdate.Quantity = newQuantity;
        }
        else
        {
            throw new InvalidOperationException("Item not found in inventory.");
        }
    }

    // 打印库存项
    public void PrintInventory()
    {
        foreach (var item in inventoryItems)
        {
            Console.WriteLine($"Item: {item.Name}, Quantity: {item.Quantity}, Price: {item.Price:C}");
        }
    }
}

// 库存项类
public class InventoryItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}