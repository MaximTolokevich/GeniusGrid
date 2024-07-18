using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositories.Implementations
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UnitOfWork> _logger;
        public IUserRepository Users => _userRepository ?? new UserRepository(this);

        public UnitOfWork(DbContextOptions<UnitOfWork> options, ILogger<UnitOfWork> logger) : base(options)
        {
            _logger = logger;
        }
        public async Task SaveChangesAsync()
        {
            try
            {
                await base.SaveChangesAsync();

                _logger.LogInformation("The changes were successfully saved to the database.");
            }
            catch
            {
                throw;
            }
        }
    }
}
