using SimpleProductApi.Config;
using SimpleProductApi.Repositories;
using SimpleProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<DbConnector>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
// builder.Services.AddTransient(typeof(IProductRepository), typeof(ProductRepository));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Dependency Injection
// Transient Object akan dibuat setiap kali perlukan/setiap ada permintaan http -> STATLESS
// builder.Services.AddTransient<>()

// Object akan digunakan dalam satu scoped
// builder.Services.AddScoped<>();

// hanya dibuat satu kali selama aplikasi hidup
// builder.Services.AddSingleton<>()

// DB -> Scoped - Ini akan dibuat setiap scoped/transaksi
// Service -> Singleton (Service bergantung pada DB)

/*
 * Lifetime Dependency Injection di .NET
 * - Transient -> Service, Repository
 * - Scoped -> DB
 * - Singleton -> Mapper (DTO -> Model) (Model -> DTO)
 */

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