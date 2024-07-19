namespace DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UsersRepository { get; }

        Task SaveChangesAsync();
    }
}
