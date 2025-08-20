/// <summary>
/// Represents a product in the shopping cart.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }
}
namespace ShoppingCart.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required decimal Price { get; set; }
    }
}
