using System;
using System.Collections.Generic;
using System.Text;
using B_Commerce.NotificationService.DomainClass;
using Microsoft.EntityFrameworkCore;

namespace B_Commerce.NotificationService.DbContext.SQLServer
{
    public class NSDbContextSQL : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<ProjectPermission> ProjectPermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=10.0.75.2;Database=NotificationService;UID=Sa;PWD='6.rq=^DP;Jn;w%|FVEPZ'");
        }
    }
}