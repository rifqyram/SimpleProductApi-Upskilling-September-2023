using SimpleProductApi.Entities;

namespace SimpleProductApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Save(Product product)
    {
        product.Id = Guid.NewGuid().ToString();
        // INSERT INTO product ...
        // EF Core -> Tracking Status
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }

    public Product? FindById(string id)
    {
        return null;
    }

    public List<Product> FindAll()
    {
        return null;
    }

    public void Delete(Product product)
    {
        // _products.Remove(product);
    }
}