using Api.Services.Models.RequestModels;
using BLL.UserService.Models;

namespace Api.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<User?> Register(RegistrationRequest model);
    }
}
