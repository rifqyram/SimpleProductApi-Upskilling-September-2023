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
    public async Task<IActionResult> CreateProduct([FromBody] Product payload)
    {
        var product = await _productService.Create(payload);
        return Created("/api/v1/products", product);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] Product payload)
    {
        var update = await _productService.Update(payload);
        return Ok(update);
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var products = await _productService.GetAll();
        return Ok(products);
    }

    // /api/products/:id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(string id)
    {
        await _productService.DeleteById(id);
        return NoContent();
    }
}