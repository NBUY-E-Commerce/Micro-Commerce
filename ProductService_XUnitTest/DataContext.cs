using B_Commerce.ProductService.DomainClasses;
using Microsoft.EntityFrameworkCore;


namespace ProductService_XUnitTest
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MasterCategory> MasterCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
