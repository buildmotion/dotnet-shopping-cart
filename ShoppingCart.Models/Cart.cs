using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public required int CustomerId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
