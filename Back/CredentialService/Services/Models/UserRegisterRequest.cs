using System.ComponentModel.DataAnnotations;

namespace Api.Services.Models
{
    public class UserRegisterRequest
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
