using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs
{
    public class CreateCustomerDto
    {
        public long CustomerId { get; init; }

        [Required]
        public string Firstname { get; init; }

        [Required]
        public string Lastname { get; init; }
    }
}
