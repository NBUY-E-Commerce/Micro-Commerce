
using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.LogService.DBContext;
using B_Commerce.LogService.Helpers.Abstract;
using B_Commerce.LogService.Helpers.Concrete;
using B_Commerce.LogService.MqServices.Abstract;
using B_Commerce.LogService.MqServices.Concrete;
using B_Commerce.LogService.Services.Abstract;
using B_Commerce.LogService.Services.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace B_Commerce.LogServiceApi
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
            services.AddControllers();
            services.AddScoped<DbContext, DataContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProjectInfoService, ProjectInfoService>();
            services.AddScoped<IProjectOwnerService, ProjectOwnerService>();
            services.AddScoped<ILogInfoService, LogInfoService>();
            services.AddScoped<IPublisher, Publisher>();
            services.AddScoped<IConsumer, Consumer>();
            services.AddScoped<IRabbitMQConnection, RabbitMQConnection>();
            services.AddScoped<IDBHelper, DBHelper>();
            services.AddScoped<IMailHelper, MailHelper>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
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

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
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
