using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Контроллер получения Customer по Id
        /// Если найден возвращается код 200 с данными о customer
        /// Если не найден возврат кода 404
        /// Если ошибка возврат кода 500
        /// </summary>
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

        /// <summary>
        /// Контроллер создания Customer
        /// Входной параметр DTO модель для создания customer
        /// Если создан без оштбок - возврат кода 200 и id созданного customer
        /// Если ошибка создания возврат кода 409 - пользователь с таким id уже существует
        /// </summary>
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