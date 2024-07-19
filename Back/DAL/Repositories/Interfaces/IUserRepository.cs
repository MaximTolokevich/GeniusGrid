using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDbEntry> GetByIdAsync(Guid id);
        Task<UserDbEntry> GetByEmailAsync(string email);
        bool Delete(Guid id);
        bool Create(UserDbEntry user);
        bool Update(UserDbEntry user);
    }
}