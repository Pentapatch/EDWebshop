using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext() { } // For use by MSTest

        // TODO: Add tables
        //public virtual DbSet<Entity> Entities { get; set; }
    }
}
