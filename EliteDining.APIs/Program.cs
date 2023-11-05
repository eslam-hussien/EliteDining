
using EliteDining.BL.IServices;
using EliteDining.BL.Services;
using EliteDining.DAL.Models;
using EliteDining.DAL.Extensions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using EliteDining.APIs.ViewModel;

namespace EliteDining.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddPersistenceLayer(builder.Configuration);
            builder.Services.AddScoped<IGenericService<Employee>, EmployeeService>();
            builder.Services.AddAutoMapper(typeof(Program));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Employee, EmployeeVewModel>().ReverseMap();
        }
    }
}
