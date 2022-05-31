using WebApi.Domain.Entities;
using WebApi.DTOs;

namespace WebApi.Domain.Repositories
{
    /// <summary>
    /// интерфейс репозитория 
    /// </summary>
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetAllAsync();

        public Task<Customer> GetByIdAsync(long id);

        public Task<long> CreateAsync(CreateCustomerDto createCustomerDTO);
    }
 
}
