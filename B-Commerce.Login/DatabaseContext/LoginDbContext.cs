using B_Commerce.Login.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace B_Commerce.Login.DatabaseContext
{
    public class LoginDbContext : DbContext
    {
        private string _connectionString;
        public LoginDbContext()
        {
            //  IConfigurationRoot configuration = new ConfigurationBuilder()
            //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //.AddJsonFile("appsettings.json")
            //.Build();
            //  _connectionString = configuration.GetConnectionString("LoginServiceDB");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Server=.;Database=LoginDatabase;User Id=sa;Password=123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            modelBuilder.Entity<User>().HasData(new User
            {
                ID = 401,
                insertDateTime = DateTime.Now,
                Username = "Visitor",
                Password = "bcommerce",
                Name = "Visitor",
                Surname = "Bcommerce",
                Email = "asd123gqwerqga14sdAS4asf5@asdasfa!@$ASFyase3hiy.com",
                IsVerified = true
            }
);
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<SocialInfo> SocialInfos { get; set; }
        public virtual DbSet<SocialType> SocialTypes { get; set; }
        public virtual DbSet<AccountVerification> AccountVerifications { get; set; }
        public virtual DbSet<PasswordChange> PasswordChanges { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

    }
}
