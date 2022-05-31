using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Repositories;
using WebApi.Domain.Repositories;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{id:long}", Name = "GetCustomerById") ]
        public async Task<IActionResult> GetCustomerAsync([FromRoute] long id)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(id);
                if (customer == null) return NotFound();
                return Ok(
                    customer
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerDto createCustomerDto)
        {
            try
            {
                var customerId = await _customerRepository.CreateAsync(createCustomerDto);
                return Ok(customerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(409, ex.Message);
            }
        }
    }
}