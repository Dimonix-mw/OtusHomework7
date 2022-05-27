using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id:long}", Name = "GetCustomerById") ]
        public Task<Customer> GetCustomerAsync([FromRoute] long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("")]
        public Task<long> CreateCustomerAsync([FromBody] Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}