// 代码生成时间: 2025-09-13 22:43:48
using System;
using System.Collections.Generic;
using System.Linq;

// 定义一个产品类，用于表示购物车中的商品
# 扩展功能模块
public class Product
# 改进用户体验
{
    public int Id { get; set; }
    public string Name { get; set; }
# 优化算法效率
    public decimal Price { get; set; }
}

// 定义购物车项类，包含产品和数量
public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
}

// 定义购物车服务类，实现购物车的基本操作
public class ShoppingCartService
{
# TODO: 优化性能
    private List<CartItem> _items;

    public ShoppingCartService()
    {
        _items = new List<CartItem>();
    }

    // 添加商品到购物车
# TODO: 优化性能
    public void AddItem(Product product, int quantity)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product), "Product cannot be null.");
# FIXME: 处理边界情况
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");

        var item = _items.FirstOrDefault(x => x.Product.Id == product.Id);
        if (item != null)
        {
            item.Quantity += quantity;
        }
        else
        {
            _items.Add(new CartItem { Product = product, Quantity = quantity });
        }
    }

    // 从购物车中移除商品
    public void RemoveItem(int productId)
    {
        var item = _items.FirstOrDefault(x => x.Product.Id == productId);
        if (item != null)
        {
            _items.Remove(item);
        }
# 优化算法效率
        else
# 扩展功能模块
        {
            throw new InvalidOperationException($"Product with ID {productId} not found in the cart.");
        }
    }

    // 获取购物车中所有商品的总价
    public decimal GetTotalPrice()
    {
# NOTE: 重要实现细节
        return _items.Sum(x => x.Product.Price * x.Quantity);
    }
# 扩展功能模块

    // 获取购物车中的所有商品项
    public List<CartItem> GetItems()
    {
        return _items;
    }
}

// 以下是一个示例用法：
/*
var productService = new ProductService(); // 假设有一个产品服务类
var product = productService.GetProductById(1); // 获取产品

var cartService = new ShoppingCartService();
cartService.AddItem(product, 2); // 添加产品到购物车

decimal totalPrice = cartService.GetTotalPrice(); // 获取总价
List<CartItem> cartItems = cartService.GetItems(); // 获取购物车商品项
*/