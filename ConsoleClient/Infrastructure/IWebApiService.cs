using ConsoleClient.Entities;

namespace ConsoleClient.Infrastructure
{
    public interface IWebApiService
    {
        public Task<Customer> GetCustomerByIdAsync(string id);
        public Task<string> CreateCustomerAsync(long id);
    }
}
