using ShoppingCart.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class CartService
    {
        public void AddItem(Cart cart, Product product, int quantity)
        {
            //VALIDATE THE QUANTITY RULE (RANGE?)
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");

            // CHECK FOR EXISTING ITEM IN CART;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (item != null)
            {
                // UPDATE QUANTITY IF ITEM EXISTS
                item.Quantity += quantity;
            }
            else
            {
                // ADD NEW ITEM TO CART;
                cart.Items.Add(new CartItem { ProductId = product.Id, Quantity = quantity });
            }
        }

        public void RemoveItem(Cart cart, int productId)
        {
            // VALIDATE INPUTS;

            // RETRIEVE ITEM FROM THE LIST;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                // REMOVE FOUND ITEM;
                cart.Items.Remove(item);
            }
        }

        public decimal GetTotal(Cart cart, List<Product> products)
        {
            // return cart.Items
            //     .Select(item => products.FirstOrDefault(p => p.Id == item.ProductId)?.Price * item.Quantity ?? 0)
            //     .Sum();

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
