using SimpleProductApi.Entities;

namespace SimpleProductApi.Services;

public interface IProductService
{
    Product Create(Product product);
    Product GetById(string id);
    List<Product> GetAll();
    Product Update(Product product);
    void DeleteById(string id);
}