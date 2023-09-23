
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ParkingProject;
using System.Reflection;

namespace PEC.UI.OData
{
    public class Program
    {
        private static readonly string ExecutingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;

        public static void Main(string[] args)
        {
            try
            {
                var hostBuilder = CreateHostBuilder(Configuration, args);

                var configuredHost = hostBuilder.Build();

                configuredHost.Run();
            }
            catch (Exception ex)
            {

             
            }
            finally
            {

            }
        }

        public static IHostBuilder CreateHostBuilder(IConfiguration configuration, string[] args) =>
   Host.CreateDefaultBuilder(args)
       .ConfigureContainer<ContainerBuilder>(builder =>
       {
           builder.RegisterModule(new AutofacModule());
       })
       .ConfigureWebHostDefaults(webBuilder =>
       {
           webBuilder.UseConfiguration(configuration);
           webBuilder.UseStartup<Startup>();
       }).UseServiceProviderFactory(new AutofacServiceProviderFactory());


        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddEnvironmentVariables()
           .Build();
    }
}














//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
