using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NetcoreTemplate.Api.WebApi.Identity;
using NetcoreTemplate.Api.WebApi.Service.Contract;
using NetcoreTemplate.Api.WebApi.Service.Implementation;
using NetcoreTemplate.Persistence.Contract.Context;

namespace NetcoreTemplate.Api.WebApi.Configuration
{
    public static partial class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            // Web Api
            services.AddCustomAuthentication(configuration);
            services.AddApiVersioning(configuration);
            services.AddCustomIdentity(configuration);
            
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<ITokenLoginService, TokenLoginService>();
            
            // Application
            services.AddApplicationServices(configuration);
//            
//            // Infrastructure
//            services.AddInfrastructureClients(configuration);
//            services.AddInfrastructureServices(configuration);
//            
            // Persistence
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                services.AddDatabaseContextDevelopment(configuration);
            else
                services.AddDatabaseContext(configuration);

            services.AddPersistenceRepositories(configuration);

            return services;
        }

        private static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidIssuer = configuration["JWT_TOKEN_ISSUER"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT_TOKEN_SECURITY_KEY"]))
                    };
                });

            return services;
        }

        private static IServiceCollection AddApiVersioning(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            
            return services;
        }

        private static IServiceCollection AddCustomIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
        
        public static void InitializeDatabases(this IApplicationBuilder app, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") return;
            
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<INetcoreTemplateDbContext>().Instance.Database.Migrate();
        }
    }
}