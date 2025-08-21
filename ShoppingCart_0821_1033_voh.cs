// 代码生成时间: 2025-08-21 10:33:57
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp
{
    // Represents a single item in the shopping cart.
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    // Represents the shopping cart functionality.
    public class ShoppingCart
    {
        private readonly List<CartItem> _items = new List<CartItem>();

        // Adds an item to the cart.
        public void AddItem(int productId, string productName, decimal price, int quantity)
        {
            // Check for existing item and update the quantity.
            var existingItem = _items.FirstOrDefault(item => item.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                // Add new item to the cart.
                _items.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity
                });
            }
        }

        // Removes an item from the cart.
        public void RemoveItem(int productId)
        {
            var itemToRemove = _items.FirstOrDefault(item => item.ProductId == productId);
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
            }
            else
            {
                throw new InvalidOperationException($"Item with product ID {productId} not found in the cart.");
            }
        }

        // Updates the quantity of an existing item in the cart.
        public void UpdateQuantity(int productId, int quantity)
        {
            var itemToUpdate = _items.FirstOrDefault(item => item.ProductId == productId);
            if (itemToUpdate != null)
            {
                if (quantity <= 0)
                {
                    RemoveItem(productId);
                }
                else
                {
                    itemToUpdate.Quantity = quantity;
                }
            }
            else
            {
                throw new InvalidOperationException($"Item with product ID {productId} not found in the cart.");
            }
        }

        // Returns the total cost of all items in the cart.
        public decimal CalculateTotal()
        {
            return _items.Sum(item => item.Price * item.Quantity);
        }

        // Returns a list of all items in the cart.
        public List<CartItem> GetItems()
        {
            return _items;
        }

        // Clears the cart.
        public void ClearCart()
        {
            _items.Clear();
        }
    }
}
