using SimpleProductApi.Entities;

namespace SimpleProductApi.Repositories;

public interface IProductRepository
{
    void Save(Product product);
    Product? FindById(string id);
    // Nullable<Product> FindById(string id);
    List<Product> FindAll();
    void Delete(Product product);
}