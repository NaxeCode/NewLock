using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace NewLock.Models
{
    public class CartItem
    {
        [JsonInclude]
        public int ProductId { get; set; }

        [JsonInclude]
        public string ProductName { get; set; }

        [JsonInclude]
        public decimal Price { get; set; }

        [JsonInclude]
        public int Quantity { get; set; }
    }

    public class Cart
    {
        [JsonInclude]
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = (decimal)product.Price,
                    Quantity = quantity
                });
            }
        }

        public void RemoveItem(string productId)
        {
            /*  var item = Items.FirstOrDefault(i => i.ProductId == productId);
             if (item != null)
             {
                 Items.Remove(item);
             } */
        }

        public decimal TotalPrice => Items.Sum(item => item.Price * item.Quantity);
    }
}