using ConsoleClient.Entities;

namespace ConsoleClient.Infrastructure
{
    public interface IWebApiService
    {
        public Task<Customer> GetCustomerByIdAsync(long id);
        public Task<long> CreateCustomerAsync(long id);
    }
}
