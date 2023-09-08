using SimpleProductApi.Entities;

namespace SimpleProductApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    public ProductRepository()
    {
        _products = new List<Product>();
    }

    public void Save(Product product)
    {
        _products.Add(product);
    }

    public Product? FindById(string id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public List<Product> FindAll()
    {
        return _products;
    }

    public void Delete(Product product)
    {
        _products.Remove(product);
    }
}