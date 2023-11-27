using Entity;
using Entity.Entities;
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

        public Task DeleteAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T ítem)
        {
            throw new NotImplementedException();
        }
    }
}
