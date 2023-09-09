using SimpleProductApi.Entities;

namespace SimpleProductApi.Repositories;

public interface IProductRepository
{
    Product Save(Product product);
    Product? FindById(string id);
    List<Product> FindAll();
    Product Update(Product product);
    void Delete(Product product);
}