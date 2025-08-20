using ShoppingCart;
using ShoppingCart.Models;
using System.Collections.Generic;
using Xunit;

namespace ShoppingCart.Tests
{
    public class CartServiceTests
    {
        [Fact]
        public void AddItem_ShouldAddNewItemToCart()
        {
            var cart = new Cart();
            var product = new Product { Id = 1, Name = "Apple", Price = 0.5m };
            var service = new CartService();

            service.AddItem(cart, product, 2);

            Assert.Single(cart.Items);
            Assert.Equal(2, cart.Items[0].Quantity);
            Assert.Equal(1, cart.Items[0].ProductId);
        }

        [Fact]
        public void RemoveItem_ShouldRemoveItemFromCart()
        {
            var cart = new Cart { Items = new List<CartItem> { new CartItem { ProductId = 1, Quantity = 2 } } };
            var service = new CartService();

            service.RemoveItem(cart, 1);

            Assert.Empty(cart.Items);
        }

        [Fact]
        public void GetTotal_ShouldReturnCorrectTotal()
        {
            var cart = new Cart { Items = new List<CartItem> { new CartItem { ProductId = 1, Quantity = 2 }, new CartItem { ProductId = 2, Quantity = 1 } } };
            var products = new List<Product> { new Product { Id = 1, Price = 0.5m }, new Product { Id = 2, Price = 1.0m } };
            var service = new CartService();

            var total = service.GetTotal(cart, products);

            Assert.Equal(2.0m, total);
        }
    }
}
