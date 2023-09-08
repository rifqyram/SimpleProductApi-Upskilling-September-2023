namespace SimpleProductApi.Entities;

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public uint Price { get; set; }
    public uint Stock { get; set; }
    
    // tipe NamaVariable
    // int vs uint
    // int menerima negative value
    // uint hanya menerima positive value
}