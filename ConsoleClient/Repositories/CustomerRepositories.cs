using ConsoleClient.Entities;
using System.Net.Http.Json;
using WebClient;

namespace ConsoleClient.Repositories
{
    public static class CustomerRepositories
    {
        public static async Task<Customer> GetCustomerByIdAsync(HttpClient client, long id)
        {
            Customer customer = null;
            var response = await client.GetAsync($"Customer/{id}");
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadFromJsonAsync<Customer>();
            }
            return customer;
        }

        public static async Task<long> CreateCustomerAsync(HttpClient client, long customerId)
        {
            var customerCreateRequest = new CustomerCreateRequest
            {
                CustomerId = customerId,
                Firstname = $"FirstName {customerId}",
                Lastname = $"LastName {customerId}"
            };
            long id = 0;
            var response = await client.PostAsJsonAsync("Customer", customerCreateRequest);
            if (response.IsSuccessStatusCode)
            {
                var idStr = await response.Content.ReadAsStringAsync();
                id = Int64.Parse(idStr);
            }
            return id;
        }
    }
}
