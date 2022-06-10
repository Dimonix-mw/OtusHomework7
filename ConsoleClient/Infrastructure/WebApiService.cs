using ConsoleClient.Entities;
using System.Net.Http;
using System.Net.Http.Json;

namespace ConsoleClient.Infrastructure
{
    public class WebApiService : IWebApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WebApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<long> CreateCustomerAsync(long id)
        {
            var client = _httpClientFactory.CreateClient("http-api");
            var customerCreateRequest = new CustomerCreateRequest
            {
                CustomerId = id,
                Firstname = $"FirstName {id}",
                Lastname = $"LastName {id}"
            };
            long response_id = 0;
            var response = await client.PostAsJsonAsync("Customer", customerCreateRequest);
            if (response.IsSuccessStatusCode)
            {
                var idStr = await response.Content.ReadAsStringAsync();
                response_id = Int64.Parse(idStr);
            }
            return id;
        }

        public async Task<Customer> GetCustomerByIdAsync(long id)
        {
            var client = _httpClientFactory.CreateClient("http-api");
            Customer customer = null;
            var response = await client.GetAsync($"Customer/{id}");
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadFromJsonAsync<Customer>();
            }
            return customer;
        }
    }
}
