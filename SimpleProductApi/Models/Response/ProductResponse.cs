namespace SimpleProductApi.Models.Response;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
    public CategoryResponse Category { get; set; }
}