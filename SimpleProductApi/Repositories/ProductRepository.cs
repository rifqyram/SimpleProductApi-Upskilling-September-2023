using SimpleProductApi.Entities;

namespace SimpleProductApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Product Save(Product product)
    {
        // product.Id = Guid.NewGuid().ToString();
        var entityEntry = _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
        return entityEntry.Entity;
    }

    public Product? FindById(string id)
    {
        // return _dbContext.Products.FirstOrDefault(product => product.Id == id);
        return null;
    }

    public List<Product> FindAll()
    {
       return _dbContext.Products.ToList();
    }

    public Product Update(Product product)
    {
        var entity = _dbContext.Products.Attach(product);
        var entry = _dbContext.Products.Update(entity.Entity);
        _dbContext.SaveChanges();
        return entry.Entity;
    }

    public void Delete(Product product)
    {
        _dbContext.Products.Remove(product);
    }
}