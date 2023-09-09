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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
    }
}