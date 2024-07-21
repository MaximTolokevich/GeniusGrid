using Api.Services.Models.RequestModels;
using Api.Services.Models.ResponseModels;

namespace Api.Services.Interfaces
{
    public interface IUserAuthenticateService
    {
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
    }
}
