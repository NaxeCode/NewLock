using NewLock.Models;

namespace NewLock.Services;

public class ProductRepository
{
    private List<Product> _products;

    public ProductRepository()
    {
        _products = new List<Product>
        {
            new Product { Id = "1", Name = "Deadbolt Lock", Price = 49.99, Description = "High-security deadbolt lock for front doors", Photo = "deadbolt.jpg" },
                new Product { Id = "2", Name = "Smart Lock", Price = 159.99, Description = "WiFi-enabled smart lock with mobile app control", Photo = "smartlock.jpg" },
                new Product { Id = "3", Name = "Padlock", Price = 15.99, Description = "Heavy-duty padlock for outdoor use", Photo = "padlock.jpg" },
                new Product { Id = "4", Name = "Car Key Fob", Price = 79.99, Description = "Replacement key fob for vehicles", Photo = "keyfob.jpg" },
                new Product { Id = "5", Name = "Key Safe", Price = 39.99, Description = "Wall-mounted key safe for secure key storage", Photo = "keysafe.jpg" }
        };
    }

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public IEnumerable<Product> Search(string query)
    {
        return _products.Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase)
        || p.Description.Contains(query, StringComparison.OrdinalIgnoreCase));
    }

    public Product GetById(string id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}