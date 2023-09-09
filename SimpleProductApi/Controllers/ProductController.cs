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
        return _productService.Create(product);
    }

    [HttpPut]
    public Product UpdateProduct([FromBody] Product product)
    {
        return _productService.Update(product);
    }

    [HttpGet]
    public List<Product> GetList()
    {
        return _productService.GetAll();
    }

    // /api/products/:id
    [HttpDelete("{id}")]
    public string DeleteById(string id)
    {
        _productService.DeleteById(id);
        return "OK";
    }
}