// 代码生成时间: 2025-08-05 09:34:38
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp
{
    public class ShoppingCartItem
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class ShoppingCartService
    {
        private readonly List<ShoppingCartItem> _items;

        public ShoppingCartService()
        {
            _items = new List<ShoppingCartItem>();
# 改进用户体验
        }
# FIXME: 处理边界情况

        // Adds an item to the cart or updates the quantity if it already exists.
        public void AddOrUpdateItem(string itemId, string itemName, decimal price, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }

            var item = _items.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
# 改进用户体验
            {
                item.Quantity += quantity;
            }
            else
# 优化算法效率
            {
                _items.Add(new ShoppingCartItem { ItemId = itemId, ItemName = itemName, Price = price, Quantity = quantity });
            }
        }
# 增强安全性

        // Removes an item from the cart.
        public void RemoveItem(string itemId)
        {
            var item = _items.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
            {
                _items.Remove(item);
            }
            else
            {
                throw new KeyNotFoundException("Item not found in the cart.");
            }
        }

        // Gets the total cost of all items in the cart.
        public decimal GetTotalCost()
        {
            return _items.Sum(item => item.Price * item.Quantity);
        }

        // Lists all items in the cart.
        public IEnumerable<ShoppingCartItem> ListItems()
        {
            return _items;
        }
    }
}
