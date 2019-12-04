using LogService.DomainClasses;
using LogService.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LogService.MyDbContext
{


    internal class LogDbContext : DbContext
    {
        private string _connectionString;
        public LogDbContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
         .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
         .AddJsonFile("appsettings.json")
         .Build();
            _connectionString = configuration.GetConnectionString("LogServiceDB");
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
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
                qeueName = "queue",
              

            });

            modelBuilder.ApplyConfiguration(new ProjectOwnerMapping());

           

            modelBuilder.Entity<ProjectOwner>().HasData(new ProjectOwner { 
                ID = 1, 
                ProjectID=1,
                Email ="hacimu@gmail.com" ,
                IsRequestEmail=true,
                
            });

          
        }
        public virtual DbSet<LogInfo> LogInfos { get; set; }

        public virtual DbSet<ProjectInfo> ProjectInfos { get; set; }

        public virtual DbSet<ProjectOwner> ProjectOwners { get; set; }



    }


}

