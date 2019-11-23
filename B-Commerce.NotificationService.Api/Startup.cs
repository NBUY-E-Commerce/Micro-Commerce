using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.NotificationService.DbContext.SQLite;
using B_Commerce.NotificationService.NotificationSender.Abstract;
using B_Commerce.NotificationService.NotificationSender.Concrete;
using B_Commerce.NotificationService.Service.Abstract;
using B_Commerce.NotificationService.Tools.ProjectAuthManager.Abstract;
using B_Commerce.NotificationService.Tools.ProjectAuthManager.Concrete;
using B_Commerce.NotificationService.Tools.QueueManager.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace B_Commerce.NotificationService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Microsoft.EntityFrameworkCore.DbContext, NSDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthControlService, SQliteAuthManager>();
            services.AddSingleton<IQueueService, B_Commerce.NotificationService.Tools.QueueManager.Concrete.CacheMQ>();
            services.AddSingleton<INotificationSender, BCNotificationSender>();
            services.AddScoped<INotificationService, B_Commerce.NotificationService.Service.Concrete.NotificationService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BCommerce Notification Service", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BCommerce Notification Service V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
