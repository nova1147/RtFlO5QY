// 代码生成时间: 2025-08-18 19:56:24
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartDemo
{
    // 定义一个商品类，用于存储商品信息
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    // 定义购物车项类，用于存储购物车中的商品及其数量
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    // 定义购物车服务类，用于处理购物车相关操作
    public class ShoppingCartService
    {
        private List<CartItem> _cartItems;

        public ShoppingCartService()
        {
            _cartItems = new List<CartItem>();
        }

        // 添加商品到购物车
        public void AddProductToCart(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");
            
            var existingItem = _cartItems.FirstOrDefault(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        // 从购物车移除商品
        public void RemoveProductFromCart(int productId)
        {
            var itemToRemove = _cartItems.FirstOrDefault(item => item.Product.Id == productId);
            if (itemToRemove != null)
            {
                _cartItems.Remove(itemToRemove);
            }
            else
            {
                throw new InvalidOperationException($"Product with ID {productId} not found in cart.");
            }
        }

        // 计算购物车总价
        public decimal CalculateTotal()
        {
            return _cartItems.Sum(item => item.Product.Price * item.Quantity);
        }

        // 获取购物车中的商品项
        public List<CartItem> GetCartItems()
        {
            return _cartItems;
        }
    }
}
