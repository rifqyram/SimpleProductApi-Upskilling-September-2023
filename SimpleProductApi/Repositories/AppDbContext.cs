using Microsoft.EntityFrameworkCore;
using SimpleProductApi.Entities;

namespace SimpleProductApi.Repositories;

public class AppDbContext : DbContext
{
    // Daftarkan disini
    public DbSet<Product> Products => Set<Product>();
    
    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}