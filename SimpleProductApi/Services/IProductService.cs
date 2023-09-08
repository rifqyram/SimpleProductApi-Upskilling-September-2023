using SimpleProductApi.Entities;

namespace SimpleProductApi.Services;

public interface IProductService
{
    void Create(Product product);
    Product GetById(string id);
    List<Product> GetAll();
    void DeleteById(string id);
}