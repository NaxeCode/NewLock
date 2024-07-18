using Microsoft.AspNetCore.Mvc;
using NewLock.Services;
using NewLock.Models;

namespace NewLock.Controllers
{
    public class SearchController : Controller
    {
        private readonly ProductRepository _productRepository;

        public SearchController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return View(new List<Product>());
            }

            var results = _productRepository.Search(query);
            return View(results);
        }

        public IActionResult Details(string id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}