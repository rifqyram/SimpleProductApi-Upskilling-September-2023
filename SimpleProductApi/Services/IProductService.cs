using SimpleProductApi.Entities;
using SimpleProductApi.Models.Response;

namespace SimpleProductApi.Services;

public interface IProductService
{
    Task<Product> Create(Product product);
    Task<Product> GetById(string id);
    Task<List<ProductResponse>> GetAll();
    Task<Product> Update(Product product);
    Task DeleteById(string id);
}