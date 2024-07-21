using DAL.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class EfRepository<T> where T : class, IEntity, new()
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> Table;
        protected EfRepository(DbContext context)
        {
            Context = context;
            Table = context.Set<T>();
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync(bool trackEntities = false)
        {
            var query = (trackEntities == false) ? Table.AsNoTracking() : Table;

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            var query = Table;

            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public virtual bool Create(T entity) {
            try
            {
                Table.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Update(T entity) {
            try
            {
                Table.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Delete(string id)
        {
            try
            {
                var entity = Context.ChangeTracker.Entries<T>().FirstOrDefault(entry => entry.Entity.Id == id)?.Entity;
                entity ??= new T { Id = id };

                Table.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual void Delete(T entity) => Table.Remove(entity);
    }
}