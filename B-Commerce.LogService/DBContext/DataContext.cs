using B_Commerce.LogService.DomainClasses;
using Microsoft.EntityFrameworkCore;
using B_Commerce.LogService.Mapping;

namespace B_Commerce.LogService.DBContext
{
    public class DataContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-A3R28NH\SQLEXPRESS;Database=LogDatabase;User Id=sa;Password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogInfoMapping());

            modelBuilder.ApplyConfiguration(new ProjectInfoMapping());

            modelBuilder.Entity<ProjectInfo>().HasData(new ProjectInfo
            {
                ID = 1,
                ProjectCode = "code",
                Password = "admin",
            }) ;

            modelBuilder.ApplyConfiguration(new ProjectOwnerMapping());



            modelBuilder.Entity<ProjectOwner>().HasData(new ProjectOwner
            {
                ID = 1,
                ProjectID = 1,
                Email = "hacimu@gmail.com",
                IsRequestEmail = true,

            });
        }

        public virtual DbSet<LogInfo> LogInfos { get; set; }

        public virtual DbSet<ProjectInfo> ProjectInfos { get; set; }

        public virtual DbSet<ProjectOwner> ProjectOwners { get; set; }

    }
}
