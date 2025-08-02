// 代码生成时间: 2025-08-03 00:25:00
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp
{
    /// <summary>
    /// Represents a shopping cart item
    /// </summary>
    public class CartItem
# 扩展功能模块
    {
# 扩展功能模块
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    /// <summary>
    /// Represents the shopping cart
    /// </summary>
    public class ShoppingCart
    {
        private readonly List<CartItem> _items = new List<CartItem>();

        /// <summary>
        /// Adds an item to the cart
        /// </summary>
        /// <param name="item">The cart item to add</param>
        public void AddItem(CartItem item)
# FIXME: 处理边界情况
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");
            }

            var existingItem = _items.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                _items.Add(item);
            }
        }

        /// <summary>
# 优化算法效率
        /// Removes an item from the cart
        /// </summary>
        /// <param name="productId">The product ID of the item to remove</param>
        public void RemoveItem(int productId)
        {
            var item = _items.FirstOrDefault(i => i.ProductId == productId);
# 增强安全性
            if (item != null)
            {
                _items.Remove(item);
# FIXME: 处理边界情况
            }
            else
# 改进用户体验
            {
                throw new InvalidOperationException($"Item with product ID {productId} not found in the cart.");
            }
        }

        /// <summary>
        /// Gets the total price of the cart
        /// </summary>
        /// <returns>Total price of the cart</returns>
        public decimal GetTotalPrice()
        {
            return _items.Sum(item => item.Price * item.Quantity);
        }

        /// <summary>
        /// Gets the list of items in the cart
        /// </summary>
        /// <returns>List of cart items</returns>
        public List<CartItem> GetItems()
        {
            return _items;
# 优化算法效率
        }
    }

    /// <summary>
    /// Program to demonstrate the shopping cart functionality
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new ShoppingCart();

            try
            {
                cart.AddItem(new CartItem { ProductId = 1, ProductName = "Product 1", Price = 100m, Quantity = 2 });
# 改进用户体验
                cart.AddItem(new CartItem { ProductId = 2, ProductName = "Product 2", Price = 200m, Quantity = 1 });

                Console.WriteLine($"Total price: {cart.GetTotalPrice()}");
                Console.WriteLine("You added the following items to your cart: ");
                foreach (var item in cart.GetItems())
                {
                    Console.WriteLine($"Product: {item.ProductName}, Price: {item.Price}, Quantity: {item.Quantity}");
                }
# 添加错误处理

                cart.RemoveItem(1);
                Console.WriteLine("You removed Product 1 from your cart.");
                Console.WriteLine("You have the following items left in your cart: ");
                foreach (var item in cart.GetItems())
                {
                    Console.WriteLine($"Product: {item.ProductName}, Price: {item.Price}, Quantity: {item.Quantity}");
                }
            }
            catch (Exception ex)
# 增强安全性
            {
# 改进用户体验
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
# TODO: 优化性能
    }
}