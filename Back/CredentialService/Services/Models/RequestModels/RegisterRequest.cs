using System.ComponentModel.DataAnnotations;

namespace Api.Services.Models.RequestModels
{
    public class RegistrationRequest
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
