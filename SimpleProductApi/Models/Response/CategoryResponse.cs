namespace SimpleProductApi.Models.Response;

public class CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ProductId { get; set; }
}