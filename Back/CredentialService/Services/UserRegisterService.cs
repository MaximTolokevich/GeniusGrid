using Api.Services.Interfaces;
using Api.Services.Models;
using BLL.UserService.Models;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace Api.Services
{
    public class UserRegisterService : IRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRegisterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User?> Register(UserRegisterRequest model)
        {
            var userExisted = await _unitOfWork.UsersRepository.GetByEmailAsync(model.Email);
            if (userExisted == null)
            {
                var user = new UserDbEntry()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    EmailConfirmed = false,
                };
                _unitOfWork.UsersRepository.Create(user);
                await _unitOfWork.SaveChangesAsync();
                return new User
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
