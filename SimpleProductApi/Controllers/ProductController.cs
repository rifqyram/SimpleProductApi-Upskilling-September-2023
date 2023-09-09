using Microsoft.AspNetCore.Mvc;
using SimpleProductApi.Entities;
using SimpleProductApi.Services;

namespace SimpleProductApi.Controllers;

[Route("api/products")]
public class ProductController : BaseController
{
    public delegate int PerformCalculation(int x, int y);
    // private readonly IProductService _productService;

    // public ProductController(IProductService productService) => _productService = productService;

    [HttpPost]
    public Product CreateProduct([FromBody] Product product)
    {
        // _productService.Create(product);
        // return product;
        return null;
    }

    [HttpGet]
    public List<Product> GetList()
    {
        // ProcessCalculate((x, y) => x * y);
        // IList, IQueryable, IEnumerable
        List<Product> products = new List<Product>
        {
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Apple",
                Price = 1000,
                Stock = 10
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Jambu",
                Price = 1000,
                Stock = 5
            }
        };

        /**
         * 1. Query Syntax
         * 2. Method -> Array Method Build in javascript | Stream Java
         * 3. Method & Query Syntax (MIX)
         */
        
        // Query Syntax
        IEnumerable<Product> productsQuery =
            from product in products
            where product.Name is "Jambu"
            select product;

        // Query Method
        IEnumerable<Product> queryMethodProduct = products.Where(product => product.Name == "Jambu");

        var queryable = products.AsQueryable();
        
        // LIMIT - Take
        // OFFSET - Skip
        // queryable.Take().Skip()

        /*
         * Perbedaan antara IEnumerable dan IQueryable
         * IEnumerable
         * - IEnumerable tersedia di namespace Systems.Collections
         * - Ini tidak ada fitur lazy load, sehingga tidak cocok digunakan untuk pagination
         *
         * IQueryable
         * - System.Linq
         * - Pagination -> lebih cocok digunakan untuk lazy load
         */
        
        // LINQ Mix Syntax
        Product? mixProduct =
            (from product in products
                where product.Name is "Jambu"
                select product).FirstOrDefault();

        return productsQuery.ToList();
    }
}