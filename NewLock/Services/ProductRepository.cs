using NewLock.Models;

namespace NewLock.Services;

public class ProductRepository
{
    private List<Product> _products;

    public ProductRepository()
    {
        string lever_description = @"The 800-Series locks are designed for use in a variety of commercial applications. Equipped with a UL listed latchbolt, these locks can be used on 3-hour fire doors. Built with independent return springs in each lever and with an optional clutch feature to protect against excessive torque, these levers resist sagging. The L-shaped lever design with less than 1/2"" gap between the handle and the door meets most accessibility codes. Compatible with many retrofit cylinders such as LSDA C500, Ilco, GMS and most High-Security brands including Medeco, Assa, Schlage Primus, Kaba Peaks, etc.";

        _products = new List<Product>
        {
            new Product { Id = "1", Ez = "181301" , Name = "Grade 2 Entry Lever", Price = 189.99, Description = lever_description },
            new Product { Id = "2", Ez = "181305" , Name = "Grade 2 Storeroom Lever", Price = 189.99, Description = lever_description}
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