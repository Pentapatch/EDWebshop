using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext() { } // For use by MSTest

        public virtual DbSet<FlowerProduct> Products { get; set; }
    }
}
