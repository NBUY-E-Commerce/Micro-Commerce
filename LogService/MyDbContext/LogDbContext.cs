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
    internal class LogDbContext: DbContext 
    {
        
        public LogDbContext(DbContextOptions<LogDbContext> options): base(options)
        {
           

        }
        public virtual DbSet<LogInfo> LogInfos { get; set; }

        
    }
}
