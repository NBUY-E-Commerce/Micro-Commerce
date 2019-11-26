using B_Commerce.Login.DomainClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace B_Commerce.Login.DatabaseContext
{
    public class LoginDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=LoginDatabase;User=sa;Password=123");
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

    }
}
