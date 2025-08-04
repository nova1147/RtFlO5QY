// 代码生成时间: 2025-08-04 22:41:02
using System;
using System.Collections.Generic;
using System.Linq;

// 库存项类
public class InventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    // 构造函数
    public InventoryItem(int id, string name, int quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }
}

// 库存管理系统类
public class InventoryManagementSystem
{
    private List<InventoryItem> _items;

    // 构造函数初始化库存列表
    public InventoryManagementSystem()
    {
        _items = new List<InventoryItem>();
    }

    // 添加库存项
    public void AddItem(InventoryItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        _items.Add(item);
    }

    // 移除库存项
    public bool RemoveItem(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item != null)
            return _items.Remove(item);
        else
            return false;
    }

    // 更新库存项的数量
    public bool UpdateQuantity(int id, int newQuantity)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            item.Quantity = newQuantity;
            return true;
        }
        else
            return false;
    }

    // 获取库存项
    public InventoryItem GetItem(int id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }

    // 列出所有库存项
    public List<InventoryItem> ListItems()
    {
        return _items;
    }
}

// 程序入口类
class Program
{
    static void Main(string[] args)
    {
        InventoryManagementSystem system = new InventoryManagementSystem();
        try
        {
            // 添加库存项
            system.AddItem(new InventoryItem(1, "Widget", 100));
            system.AddItem(new InventoryItem(2, "Gadget", 150));

            // 更新库存项数量
            system.UpdateQuantity(1, 90);

            // 移除库存项
            system.RemoveItem(2);

            // 列出所有库存项
            List<InventoryItem> items = system.ListItems();
            foreach (var item in items)
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}