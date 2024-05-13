using Microsoft.EntityFrameworkCore;
using Server_API.Context;
using Server_API.Mappings;
using Server_API.Services;
using System.Reflection;

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

            var assembly = Assembly.GetExecutingAssembly();
            builder.Services.AddAutoMapper(assembly);

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
