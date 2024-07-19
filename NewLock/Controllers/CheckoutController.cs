using Microsoft.AspNetCore.Mvc;
using NewLock.Services;
using NewLock.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NewLock.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly StripeService _stripeService;
        private readonly CartService _cartService;
        private readonly IConfiguration _configuration;

        public CheckoutController(StripeService stripeService, CartService cartService, IConfiguration configuration)
        {
            _stripeService = stripeService;
            _cartService = cartService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            ViewData["StripePublishableKey"] = _configuration["Stripe:PublishableKey"];
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession()
        {
            var cart = _cartService.GetCart();
            var domain = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            var options = new
            {
                success_url = $"{domain}/Checkout/Success",
                cancel_url = $"{domain}/Checkout/Cancel"
            };

            string sessionId = await _stripeService.CreateCheckoutSessionAsync(cart, options.success_url, options.cancel_url);

            return Json(new { id = sessionId });
        }

        public IActionResult Success()
        {
            // In a real application, you would retrieve the order details from your database
            // based on the session ID or customer ID returned by Stripe
            ViewData["OrderId"] = "12345"; // Placeholder
            ViewData["TotalAmount"] = "$100.00"; // Placeholder

            // Clear the cart after successful payment
            _cartService.ClearCart();

            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }
    }
}