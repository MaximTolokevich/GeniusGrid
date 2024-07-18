using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDbEntry> GetByIdAsync(int id);
        bool Delete(int id);
        bool Create(UserDbEntry user);
        bool Update(UserDbEntry user);
    }
}