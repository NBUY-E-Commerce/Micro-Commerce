using LogService.DomainClasses;
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
        public virtual DbSet<LogInfo> LogInfos { get; set; }


    }


}

