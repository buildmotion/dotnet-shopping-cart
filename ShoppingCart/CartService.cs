using ShoppingCart.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class CartService
    {
        public void AddItem(Cart cart, Product product, int quantity)
        {
            var item = cart.Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (item != null)
            {
                item.Quantity += quantity;
            }
            else
            {
                cart.Items.Add(new CartItem { ProductId = product.Id, Quantity = quantity });
            }
        }

        public void RemoveItem(Cart cart, int productId)
        {
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                cart.Items.Remove(item);
            }
        }

        public decimal GetTotal(Cart cart, List<Product> products)
        {
            decimal total = 0;
            foreach (var item in cart.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                if (product != null)
                {
                    total += product.Price * item.Quantity;
                }
            }
            return total;
        }
    }
}
