
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using ParkingProject.DataLayer.Context;
using System.Net.Http.Headers;

namespace ParkingProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ParkingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ParkingConnectionString")));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var service = app.ApplicationServices.GetRequiredService<ParkingContext>())
            {
                service.Database.Migrate();
            }

            string[] corsDomains = Configuration["CorsDomains:Domains"].Split(",");

            app.UseCors(options => options.WithOrigins(corsDomains).AllowAnyMethod().AllowAnyHeader());

            AutoMigrationDb(app);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private void AutoMigrationDb(IApplicationBuilder app)
        {
            bool.TryParse(Configuration["ApiParameters:AutoMigrateDb"], out bool autoMigrateDb);

            if (autoMigrateDb)
            {
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<ParkingContext>();
                    context.Database.SetCommandTimeout(int.MaxValue);
                    context.Database.EnsureCreated();
                    context.Database.Migrate();
                }
            }
        }
    }
}
