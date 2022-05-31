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
        /// ���������� ��������� Customer �� Id
        /// ���� ������ ������������ ��� 200 � ������� � customer
        /// ���� �� ������ ������� ���� 404
        /// ���� ������ ������� ���� 500
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
        /// ���������� �������� Customer
        /// ������� �������� DTO ������ ��� �������� customer
        /// ���� ������ ��� ������ - ������� ���� 200 � id ���������� customer
        /// ���� ������ �������� ������� ���� 409 - ������������ � ����� id ��� ����������
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