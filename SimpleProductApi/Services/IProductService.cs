using SimpleProductApi.Entities;

namespace SimpleProductApi.Services;

public interface IProductService
{
    Task<Product> Create(Product product);
    Task<Product> GetById(string id);
    Task<List<Product>> GetAll();
    Task<Product> Update(Product product);
    Task DeleteById(string id);
}