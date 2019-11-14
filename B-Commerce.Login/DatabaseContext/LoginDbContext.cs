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
            optionsBuilder.UseSqlServer("data source=10.0.75.2;initial catalog=LoginDB3;user id=sa;password=Jal50y1.;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder); 
        }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
