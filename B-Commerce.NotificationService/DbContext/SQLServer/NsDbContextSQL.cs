﻿using System;
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
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-6JDHFRJ;Database=NotificationService;Trusted_Connection=True");
        }
    }
}
