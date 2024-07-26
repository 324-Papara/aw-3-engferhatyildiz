using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Para.Data.Domain;


namespace Para.Data.DapperRepository
{
    public class CustomerRepository : IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;

        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = CreateConnection();
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("MsSqlConnection"));
        }

        public async Task<Customer?> GetCustomerWithDetailsAsync(long customerId)
        {
            const string query = "\n            SELECT * FROM Customer WHERE Id = @CustomerId;\n            SELECT * FROM CustomerDetail WHERE CustomerId = @CustomerId;\n            SELECT * FROM CustomerAddress WHERE CustomerId = @CustomerId;\n            SELECT * FROM CustomerPhone WHERE CustomerId = @CustomerId;\n        ";

            using (var multi = await _connection.QueryMultipleAsync(query, new { CustomerId = customerId }))
            {
                var customer = await multi.ReadFirstOrDefaultAsync<Customer>();
                if (customer != null)
                {
                    customer.CustomerDetail = await multi.ReadFirstOrDefaultAsync<CustomerDetail>();
                    customer.CustomerAddresses = (await multi.ReadAsync<CustomerAddress>()).ToList();
                    customer.CustomerPhones = (await multi.ReadAsync<CustomerPhone>()).ToList();
                }
                return customer;
            }
        }

        public void Dispose() => _connection?.Dispose();
    }
}
