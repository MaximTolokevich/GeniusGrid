using System.ComponentModel.DataAnnotations;

namespace Api.Services.Models.RequestModels
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
