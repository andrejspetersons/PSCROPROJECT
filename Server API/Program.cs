using Microsoft.EntityFrameworkCore;
using Server_API.Context;
using Server_API.Services;
using Server_API.Services.AccountantService;
using Server_API.Services.UserService;
using System.Reflection;
using FluentValidation;
using Server_API.Services.FilterSwitcher;
using Server_API.Services.FilterService;

namespace Server_API
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
            builder.Services.AddDbContextPool<PSICRODbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("psi-cro"))
                );

            builder.Services.AddScoped<ValidationService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAccountantService, AccountantService>();
            builder.Services.AddScoped<IFilterSwitcher, FilterSwitcher>();
            builder.Services.AddScoped<IFilterService, FilterService>();

            var assembly = Assembly.GetExecutingAssembly();
            builder.Services.AddAutoMapper(assembly);
            builder.Services.AddValidatorsFromAssembly(assembly);
            
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
