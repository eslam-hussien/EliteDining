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
            services.AddScoped<IGenericRepo<Bill>, BillRepo>();
            services.AddScoped<IGenericRepo<Customer>, CustomerRepo>();
            services.AddScoped<IGenericRepo<Employee>, EmployeeRepo>();
            services.AddScoped<IGenericRepo<Food>, FoodRepo>();
            services.AddScoped<IGenericRepo<Order>, OrderRepo>();
            services.AddScoped<IGenericRepo<Payment>, PaymentRepo>();
            services.AddScoped<IGenericRepo<EmployeeRole>, RoleRepo>();
            services.AddScoped<IGenericRepo<Table>, TableRepo>();
            services.AddScoped<IGenericRepo<Booking>, BookingRepo>();
            services.AddScoped<TableRepo>();
            services.AddScoped<IGenericRepo<Contact>, ContactRepo>();

        }
        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGenericService<Bill>, BillService>();
            services.AddScoped<IGenericService<Customer>, CustomerService>();
            services.AddScoped<IGenericService<Employee>, EmployeeService>();
            services.AddScoped<IGenericService<Food>, FoodService>();
            services.AddScoped<IGenericService<Order>, OrderService>();
            services.AddScoped<IGenericService<Payment>, PaymentService>();
            services.AddScoped<IGenericService<EmployeeRole>, RoleService>();
            services.AddScoped<IGenericService<Table>, TableService>();
            services.AddScoped<IBookingService,BookingService>();
            services.AddScoped<IGenericService<Contact>, ContactService>();

        }
    }
}
