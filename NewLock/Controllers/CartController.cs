using Microsoft.AspNetCore.Mvc;
using NewLock.Services;
using NewLock.Models;

namespace YourNamespace.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly ProductRepository _productRepository;

        public CartController(CartService cartService, ProductRepository productRepository)
        {
            _cartService = cartService;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        public IActionResult AddToCart(string productId, int quantity = 1)
        {
            var product = _productRepository.GetById(productId);
            if (product != null)
            {
                _cartService.AddToCart(product, quantity);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(string productId)
        {
            _cartService.RemoveFromCart(productId);
            return RedirectToAction("Index");
        }
    }
}