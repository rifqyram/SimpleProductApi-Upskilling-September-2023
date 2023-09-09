using Microsoft.AspNetCore.Mvc;
using SimpleProductApi.Entities;
using SimpleProductApi.Services;

namespace SimpleProductApi.Controllers;

[Route("api/products")]
public class ProductController : BaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public Product CreateProduct([FromBody] Product product)
    {
        _productService.Create(product);
        return product;
    }

    [HttpGet]
    public List<Product> GetList()
    {
        return null;
    }
}