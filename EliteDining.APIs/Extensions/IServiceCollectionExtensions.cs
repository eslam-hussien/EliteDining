using EliteDining.BL.IServices;
using EliteDining.BL.Services;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using EliteDining.DAL.Repo;
using Microsoft.EntityFrameworkCore;

namespace EliteDining.DAL.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
            services.AddServices();
        }



        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EliteDiningDbContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(EliteDiningDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepo<Employee>, EmployeeRepo>();
        }
        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGenericService<Employee>, EmployeeService>();
        }
    }
}
