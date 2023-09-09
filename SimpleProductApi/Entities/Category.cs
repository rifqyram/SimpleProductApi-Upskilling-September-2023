using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleProductApi.Entities;

[Table(name: "category")]
public class Category
{
    [Key, Column(name: "id")] public Guid Id { get; set; }
    [Column(name: "name")] public string Name { get; set; }

    public ICollection<Product>? Products { get; set; }
}