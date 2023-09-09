using Enigma.DatingNet.Repositories;
using SimpleProductApi.Entities;
using SimpleProductApi.Repositories;

namespace SimpleProductApi.Services;

public class ProductService : IProductService
{
    // private readonly IProductRepository _productRepository;
    private readonly IRepository<Product> _repository;
    private readonly IPersistence _persistence;

    public ProductService(IRepository<Product> repository, IPersistence persistence)
    {
        _repository = repository;
        _persistence = persistence;
        // _productRepository = productRepository;
    }


    public async Task<Product> Create(Product product)
    {
        var savedProduct = await _repository.SaveAsync(product);
        await _persistence.SaveChangesAsync();
        return savedProduct;
    }

    public async Task<Product> GetById(string id)
    {
        var product = await _repository.FindByIdAsync(Guid.Parse(id));
        if (product == null) throw new Exception("product not found");
        return product;
    }

    public async Task<List<Product>> GetAll()
    {
        var products = await _repository.FindAllAsync();
        return products.ToList();
    }

    public async Task<Product> Update(Product product)
    {
        await GetById(product.Id.ToString());
        var update = _repository.Update(product);
        await _persistence.SaveChangesAsync();
        return update;
    }

    public async Task DeleteById(string id)
    {
        var product = await GetById(id);
        _repository.Delete(product);
        await _persistence.SaveChangesAsync();
    }
}