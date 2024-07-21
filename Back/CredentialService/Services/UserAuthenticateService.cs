using Api.Services.Interfaces;
using Api.Services.Models.RequestModels;
using Api.Services.Models.ResponseModels;
using BLL.TokenHandler;
using DAL.Repositories.Interfaces;
using System.Security.Claims;

namespace Api.Services
{
    public class UserAuthenticateService : IUserAuthenticateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISecurityTokenHandler _securityTokenHandler;

        public UserAuthenticateService(IUnitOfWork unitOfWork, ISecurityTokenHandler securityTokenHandler)
        {
            _unitOfWork = unitOfWork;
            _securityTokenHandler = securityTokenHandler;
        }
        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            var userExisted = await _unitOfWork.UsersRepository.GetByEmailAsync(model.Email);
            if (userExisted != null && userExisted.Password.Trim().Equals(model.Password))
            {
                var claims = new List<Claim> {
                    new(ClaimTypes.Name, model.Email)
                };

                var token = _securityTokenHandler.CreateToken(claims);
                return new AuthenticateResponse
                {
                    Email = userExisted.Email,
                    Token = token,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
