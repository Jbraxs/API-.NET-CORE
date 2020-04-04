using Contracts;
using Entities.Models;
using Entities.Helpers;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.Text;
using ProyectWeight.Users;

namespace ProyectWeight.Extensions
{
    public static class ServiceExtensions
    {
            public static void ConfigureCors(this IServiceCollection services)
            {
                services.AddCors(options =>
                {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());                    
                });
            }

            public static void ConfigureIISIntegration(this IServiceCollection services)
            {
                services.Configure<IISOptions>(options => { });
            }
            
            public static void ConfigureLoggerService(this IServiceCollection services)
            {
                services.AddSingleton<ILoggerManager, LoggerManager>();
            }

            public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
            {
                var connectionString = config["mysqlconnection:connectionString"];
                services.AddDbContext<proyect_weightContext>(o => o.UseMySql(connectionString));
            }

            public static void ConfigureRepositoryWrapper(this IServiceCollection services)
            {
                services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            }

            public static void ConfigureToken(this IServiceCollection services, IConfiguration Configuration)
            {
                // configure strongly typed settings objects
                var appSettingsSection = Configuration.GetSection("AppSettings");
                services.Configure<AppSettings>(appSettingsSection);

                // configure jwt authentication
                var appSettings = appSettingsSection.Get<AppSettings>();
                var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

                services.AddScoped<IUsers, UsersToken>();
            }
    }
}
