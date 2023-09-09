using Enigma.DatingNet.Repositories;
using SimpleProductApi.Entities;
using SimpleProductApi.Models.Response;
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
        var product = await _repository.FindAsync(p => p.Id == Guid.Parse(id), new[] { "Category" });
        if (product == null) throw new Exception("product not found");
        return product;
    }

    public async Task<List<ProductResponse>> GetAll()
    {
        var products = await _repository.FindAllAsync(new[] { "Category" });
        // Looping for

        // List<ProductResponse> productResponses = new List<ProductResponse>();
        // foreach (var product in products)
        // {
        //     productResponses.Add(new ProductResponse
        //     {
        //         Id = default,
        //         Name = null,
        //         Price = 0,
        //         Stock = 0,
        //         Category = null
        //     });
        // }

        var productResponses = products.Select(product => new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Category = new CategoryResponse
            {
                Id = product.CategoryId,
                Name = product.Category.Name,
                ProductId = product.Id
            }
        }).ToList();
        
        return productResponses;
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