using EDWebshop.Contracts.Entities;
using EDWebshop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EDWebshop.Data.Repositories
{
    public class FlowerProductRepository(DataContext context) : Repository<FlowerProduct, DataContext>(context)
    {
        public async override Task<IEnumerable<FlowerProduct>> GetAllAsync() =>
            await _dataContext.Products
            .Include(x => x.Variants)
            .AsNoTracking()
            .ToListAsync();

        public async override Task<FlowerProduct?> GetAsync(int id) =>
             await _dataContext.Products
            .Include(x => x.Variants)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}