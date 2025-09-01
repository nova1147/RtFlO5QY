// 代码生成时间: 2025-09-02 02:32:40
using System;
using System.Collections.Generic;
using System.Linq;

// Represents a product in the cart
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

// Represents a shopping cart
public class ShoppingCart
{
    // List of products in the cart
    private List<Product> _products = new List<Product>();

    // Adds a product to the cart
    public void AddProduct(Product product)
    {
        // Check if product already exists in the cart
        var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            // If product exists, increase the quantity
            existingProduct.Quantity += product.Quantity;
        }
        else
        {
            // If product does not exist, add it to the cart
            _products.Add(product);
        }
    }

    // Removes a product from the cart
    public void RemoveProduct(Product product)
    {
        var productToRemove = _products.FirstOrDefault(p => p.Id == product.Id);
        if (productToRemove != null)
        {
            if (productToRemove.Quantity > 1)
            {
                productToRemove.Quantity -= 1;
            }
            else
            {
                _products.Remove(productToRemove);
            }
        }
        else
        {
            throw new InvalidOperationException("Product not found in the cart.");
        }
    }

    // Calculates the total price of the cart
    public decimal CalculateTotalPrice()
    {
        return _products.Sum(p => p.Price * p.Quantity);
    }

    // Returns a list of all products in the cart
    public List<Product> GetProducts()
    {
        return _products;
    }
}

// Example usage of ShoppingCart
public class Program
{
    public static void Main()
    {
        var cart = new ShoppingCart();

        // Add products to the cart
        cart.AddProduct(new Product { Id = 1, Name = "Product 1", Price = 10m, Quantity = 2 });
        cart.AddProduct(new Product { Id = 2, Name = "Product 2", Price = 20m, Quantity = 1 });

        // Get cart total price
        Console.WriteLine("Total Price: " + cart.CalculateTotalPrice());

        // Remove a product from the cart
        cart.RemoveProduct(new Product { Id = 1, Name = "Product 1", Price = 10m, Quantity = 1 });

        // Get updated cart total price
        Console.WriteLine("Updated Total Price: " + cart.CalculateTotalPrice());
    }
}