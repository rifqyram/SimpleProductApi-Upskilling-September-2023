using SimpleProductApi.Entities;
using SimpleProductApi.Repositories;

namespace SimpleProductApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void Create(Product product)
    {
        _productRepository.Save(product);
    }

    public Product GetById(string id)
    {
        // Product? product = _productRepository.FindById(id);
        var product = _productRepository.FindById(id);
        if (product != null) return product;
        throw new Exception("product not found");
    }

    public List<Product> GetAll()
    {
        return _productRepository.FindAll();
    }

    public void DeleteById(string id)
    {
        var product = GetById(id);
        _productRepository.Delete(product);
    }
}