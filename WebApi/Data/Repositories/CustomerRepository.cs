using Dapper;
using System.Data;
using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;
using WebApi.DTOs;

namespace WebApi.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;
        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            string sqlQuery = "SELECT * FROM Customers";
            using var connection = _context.CreateConnection();
            var customers = await connection.QueryAsync<Customer>(sqlQuery);
            return customers.ToList();
        }

        public async Task<Customer> GetByIdAsync(long id)
        {
            string sqlQuery = "SELECT * FROM Customers WHERE CustomerId = @Id";
            using var connection = _context.CreateConnection();
            var customer = await connection.QuerySingleAsync<Customer>(sqlQuery, new { Id = id });
            return customer;
        }

        public async Task<long> CreateAsync(CreateCustomerDto createCustomerDto)
        {
            string sqlQuery = "INSERT into Customers (CustomerId, Firstname, Lastname) OUTPUT INSERTED.CustomerId values (@CustomerId, @Firstname, @Lastname)";
            using var connection = _context.CreateConnection();
            var customerId = await connection.ExecuteScalarAsync<long>(sqlQuery, createCustomerDto);
            //Console.Write(customerId);
            return customerId;
        }
    }
}
