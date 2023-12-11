using EDWebshop.Contracts;

namespace EDWebshop.Data.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> CreateAsync(T item);
        Task DeleteAsync(T item);
        Task<T?> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T item);
    }
}
