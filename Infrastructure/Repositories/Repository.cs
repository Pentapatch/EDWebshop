using EDWebshop.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EDWebshop.Data.Repositories
{
    public class Repository<T, T2>(T2 context) : IRepository<T>
        where T : class, IEntity
        where T2 : DbContext
    {
        protected readonly T2 _dataContext = context;

        public virtual async Task<T> CreateAsync(T item)
        {
            await _dataContext.Set<T>().AddAsync(item);
            await _dataContext.SaveChangesAsync();
            return item;
        }

        public virtual async Task DeleteAsync(T item)
        {
            _dataContext.Set<T>().Remove(item);
            await _dataContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() =>
            await _dataContext.Set<T>().ToListAsync();

        public virtual async Task<T?> GetAsync(int id) =>
            await _dataContext.Set<T>().FindAsync(id) ??
            await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id); // Note: Comprise fallback for MSTest

        public virtual async Task UpdateAsync(T item)
        {
            _dataContext.Set<T>().Update(item);
            await _dataContext.SaveChangesAsync();
        }
    }
}