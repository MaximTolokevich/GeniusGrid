using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDbEntry> GetByIdAsync(string id);
        Task<UserDbEntry> GetByEmailAsync(string email);
        bool Delete(string id);
        bool Create(UserDbEntry user);
        bool Update(UserDbEntry user);
    }
}