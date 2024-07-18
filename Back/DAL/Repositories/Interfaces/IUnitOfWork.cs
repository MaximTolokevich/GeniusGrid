namespace DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        Task SaveChangesAsync();
    }
}
