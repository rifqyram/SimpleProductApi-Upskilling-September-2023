using Npgsql;

namespace SimpleProductApi.Config;

public class DbConnector
{
    private readonly IConfiguration _configuration;

    public DbConnector(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public NpgsqlConnection Connect()
    {
        NpgsqlConnection connection;
        try
        {
            connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return connection;
    }
}