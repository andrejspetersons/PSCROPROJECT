using Microsoft.EntityFrameworkCore;
using Server_API.Context;
using Server_API.Services;
using Server_API.Services.AccountantService;
using Server_API.Services.UserService;
using System.Reflection;
using FluentValidation;
using Server_API.Services.FilterSwitcher;
using Server_API.Services.FilterService;
using Server_API.Services.ClientService;
using Server_API.Services.CompanyServices;
using Serilog;
using Serilog.Events;
using Server_API.Services.ValidationServices;

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

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAccountantService, AccountantService>();
            builder.Services.AddScoped<IFilterSwitcher, FilterSwitcher>();
            builder.Services.AddScoped<IFilterService, FilterService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ICompanyServices, CompanyServices>();
            builder.Services.AddScoped<IDuplicateService, DuplicateService>();
            builder.Services.AddTransient<IValidator<string>, ReceiptValidator>();
            builder.Services.AddTransient<IValidator<string>, CompanyServiceValidator>();

            var assembly = Assembly.GetExecutingAssembly();
            builder.Services.AddAutoMapper(assembly);
            builder.Services.AddValidatorsFromAssembly(assembly);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Logger(lg=>lg
                    .Filter.ByIncludingOnly(e=>e.Level==LogEventLevel.Information)
                    .WriteTo.File("LogFiles/Information_Logs/logInfo-.txt",rollingInterval:RollingInterval.Day))
                .WriteTo.Logger(lg => lg
                    .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning)
                    .WriteTo.File("LogFiles/Warning_Logs/logWarn-.txt", rollingInterval: RollingInterval.Day))
                .WriteTo.Logger(lg => lg
                    .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
                    .WriteTo.File("LogFiles/Error_Logs/logError-.txt", rollingInterval: RollingInterval.Day))
                .CreateLogger();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseAuthorization();
            app.Urls.Add("http://localhost:5239");



            app.MapControllers();
            

            app.Run();
        }
    }
}
