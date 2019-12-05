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
            optionsBuilder.UseSqlServer("Server=.;Database=LoginDatabaseDb;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
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
