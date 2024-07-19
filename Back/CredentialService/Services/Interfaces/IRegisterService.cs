using Api.Services.Models;
using BLL.UserService.Models;

namespace Api.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<User?> Register(UserRegisterRequest model);
    }
}
