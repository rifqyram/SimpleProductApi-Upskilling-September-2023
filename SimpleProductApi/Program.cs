using Enigma.DatingNet.Repositories;
using Enigma.DatingNet.Repositories.Impls;
using Microsoft.EntityFrameworkCore;
using SimpleProductApi.Repositories;
using SimpleProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration
        .GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IPersistence, DbPersistence>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();