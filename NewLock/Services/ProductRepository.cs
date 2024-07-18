using NewLock.Models;

namespace NewLock.Services;

public class ProductRepository
{
    private List<Product> _products;

    public ProductRepository()
    {
        _products = new List<Product>
        {
            new Product { Id = "1", Ez = "181301" , Name = "LSDA GRADE 2 ENTRY LEVER EDMONTON UL 2-3/4\" SCHLAGE C SATIN CHROME 181301 - 800ED26D SC2-3/4UL", Price = 49.99, Description = @"The 800-Series locks are designed for use in a variety of commercial applications. Equipped with a UL listed latchbolt, these locks can be used on 3-hour fire doors. Built with independent return springs in each lever and with an optional clutch feature to protect against excessive torque, these levers resist sagging. The L-shaped lever design with less than 1/2"" gap between the handle and the door meets most accessibility codes. Compatible with many retrofit cylinders such as LSDA C500, Ilco, GMS and most High-Security brands including Medeco, Assa, Schlage Primus, Kaba Peaks, etc."},
                new Product { Id = "2", Ez = "" , Name = "Smart Lock", Price = 159.99, Description = "WiFi-enabled smart lock with mobile app control"},
                new Product { Id = "3", Ez = "" , Name = "Padlock", Price = 15.99, Description = "Heavy-duty padlock for outdoor use"},
                new Product { Id = "4", Ez = "" , Name = "Car Key Fob", Price = 79.99, Description = "Replacement key fob for vehicles"},
                new Product { Id = "5", Ez = "" , Name = "Key Safe", Price = 39.99, Description = "Wall-mounted key safe for secure key storage"}
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