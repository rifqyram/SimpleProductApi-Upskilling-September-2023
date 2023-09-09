using Npgsql;
using SimpleProductApi.Config;
using SimpleProductApi.Entities;

namespace SimpleProductApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DbConnector _dbConnector;

    public ProductRepository(DbConnector connector)
    {
        _dbConnector = connector;
    }

    public void Save(Product product)
    {
        var npgsqlConnection = _dbConnector.Connect();
        npgsqlConnection.Open();
        try
        {
            const string query = "INSERT INTO product VALUES ($1, $2, $3, $4)";
            var command = new NpgsqlCommand(query, npgsqlConnection)
            {
                Parameters =
                {
                    new NpgsqlParameter { Value = Guid.NewGuid().ToString() },
                    new NpgsqlParameter { Value = product.Name },
                    new NpgsqlParameter { Value = product.Price },
                    new NpgsqlParameter { Value = product.Stock },
                }
            };
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            npgsqlConnection.Close();
        }
    }

    public Product? FindById(string id)
    {
        return null;
    }

    public List<Product> FindAll()
    {
        var npgsqlConnection = _dbConnector.Connect();
        npgsqlConnection.Open();
        var products = new List<Product>();

        try
        {
            const string query = "SELECT id, name, price, stock FROM product";
            var command = new NpgsqlCommand(query, npgsqlConnection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var product = new Product
                {
                    Id = reader["id"].ToString(),
                    Name = reader["name"].ToString(),
                    Price = Convert.ToInt32(reader["price"]),
                    Stock = Convert.ToInt32(reader["stock"])
                };
                products.Add(product);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            npgsqlConnection.Close();
        }

        return products;
    }

    public void Delete(Product product)
    {
        // _products.Remove(product);
    }
}