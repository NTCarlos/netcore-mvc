using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using netcore_mvc.Data;

namespace WebUI.ServicesExtension
{
    public static class ServicesExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Use Sqlite for development purposes
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    configuration.GetConnectionString("SQLiteConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        public static void AddRegisteredServices(this IServiceCollection services, IConfiguration configuration)
        {
           //Put your services here ...

           //     services.AddTransient<IExampleService, ExampleService>();
           //     ...
           //
        }
    }
}
