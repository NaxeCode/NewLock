using Microsoft.AspNetCore.Http;
using System.Text.Json;
using NewLock.Models;
using System.Threading.Tasks;

namespace NewLock.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CartSessionKey = "Cart";

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Cart GetCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            string cartJson = session.GetString(CartSessionKey);
            return cartJson == null ? new Cart() : JsonSerializer.Deserialize<Cart>(cartJson);
        }

        public void SaveCart(Cart cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString(CartSessionKey, JsonSerializer.Serialize(cart));
        }

        public void AddToCart(Product product, int quantity)
        {
            var cart = GetCart();
            cart.AddItem(product, quantity);
            SaveCart(cart);
        }

        public void RemoveFromCart(string productId)
        {
            var cart = GetCart();
            cart.RemoveItem(productId);
            SaveCart(cart);
        }

        public async Task<int> GetCartItemCountAsync()
        {
            var cart = GetCart();
            return cart.Items.Sum(item => item.Quantity);
        }
    }
}