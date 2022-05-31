using System.ComponentModel.DataAnnotations;

namespace WebApi.Domain.Entities
{
    public class Customer
    {
        public long CustomerId { get; init; }
        
        [Required]
        public string Firstname { get; init; }

        [Required]
        public string Lastname { get; init; }
    }
}