using Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<T, T2>(T2 context) : IRepository<T> 
        where T : class, IEntity
        where T2 : DbContext
    {
        private readonly T2 _dataContext = context;

        public async Task<T> CreateAsync(T item)
        {
            await _dataContext.Set<T>().AddAsync(item);
            await _dataContext.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(T item)
        {
            _dataContext.Set<T>().Remove(item);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => 
            await _dataContext.Set<T>().ToListAsync();

        public async Task<T?> GetAsync(int id) => 
            await _dataContext.Set<T>().FindAsync(id) ??
            await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id); // Note: Comprise fallback for MSTest

        public async Task UpdateAsync(T ítem)
        {
            _dataContext.Set<T>().Update(ítem);
            await _dataContext.SaveChangesAsync();
        }
    }
}