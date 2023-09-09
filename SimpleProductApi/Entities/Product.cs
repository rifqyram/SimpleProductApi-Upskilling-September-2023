namespace SimpleProductApi.Entities;

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
    
    // tipe NamaVariable
    // int vs uint
    // int menerima negative value
    // uint hanya menerima positive value
}