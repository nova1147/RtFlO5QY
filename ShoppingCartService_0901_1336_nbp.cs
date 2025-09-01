// 代码生成时间: 2025-09-01 13:36:45
/// <summary>
/// Represents a simple shopping cart service.
/// </summary>
public class ShoppingCartService
{
    /// <summary>
    /// Internal storage for the shopping cart items.
    /// </summary>
    private List<CartItem> _items = new List<CartItem>();

    /// <summary>
    /// Adds an item to the shopping cart.
    /// </summary>
    /// <param name="item">Item to be added to the cart.</param>
    /// <returns>The updated cart item.</returns>
    public CartItem AddItem(CartItem item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");
        }

        var existingItem = _items.FirstOrDefault(i => i.ProductId == item.ProductId);
        if (existingItem != null)
        {
            existingItem.Quantity++;
            return existingItem;
        }
        else
        {
            _items.Add(item);
            return item;
        }
    }

    /// <summary>
    /// Removes an item from the shopping cart.
    /// </summary>
    /// <param name="productId">The product ID of the item to be removed.</param>
    public void RemoveItem(int productId)
    {
        var itemToRemove = _items.FirstOrDefault(i => i.ProductId == productId);
        if (itemToRemove != null)
        {
            _items.Remove(itemToRemove);
        }
        else
        {
            throw new InvalidOperationException("Item not found in the cart.");
        }
    }

    /// <summary>
    /// Updates the quantity of an item in the shopping cart.
    /// </summary>
    /// <param name="productId">The product ID of the item to be updated.</param>
    /// <param name="quantity">The new quantity of the item.</param>
    public void UpdateQuantity(int productId, int quantity)
    {
        var itemToUpdate = _items.FirstOrDefault(i => i.ProductId == productId);
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
            throw new InvalidOperationException("Item not found in the cart.");
        }
    }

    /// <summary>
    /// Clears all items from the shopping cart.
    /// </summary>
    public void ClearCart()
    {
        _items.Clear();
    }

    /// <summary>
    /// Retrieves the current items in the shopping cart.
    /// </summary>
    /// <returns>A list of cart items.</returns>
    public List<CartItem> GetItems()
    {
        return _items;
    }
}

/// <summary>
/// Represents a cart item.
/// </summary>
public class CartItem
{
    /// <summary>
    /// The product ID of the cart item.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// The quantity of the cart item.
    /// </summary>
    public int Quantity { get; set; }
}
