using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleProductApi.Entities;

[Table(name: "product")]
public class Product
{
    [Key, Column(name: "id")] public string Id { get; set; }
    [Column(name: "name")] public string Name { get; set; }
    [Column(name: "price")] public int Price { get; set; }
    [Column(name: "stock")] public int Stock { get; set; }
}