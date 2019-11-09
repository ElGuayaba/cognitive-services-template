using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CognitiveServicesTemplate.Persistence.Contract;
using CognitiveServicesTemplate.Persistence.Contract.Context;
using CognitiveServicesTemplate.Persistence.Implementation;
using CognitiveServicesTemplate.Persistence.Implementation.Context;
using Scrutor;

namespace CognitiveServicesTemplate.Api.WebApi.Configuration
{
    public static partial class DependencyInjectionExtension
    {
        private static IServiceCollection AddDatabaseContextDevelopment(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ICognitiveServicesTemplateDbContext, CognitiveServicesTemplateDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                    
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            });

            return services;
        }
        
        private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ICognitiveServicesTemplateDbContext, CognitiveServicesTemplateDbContext>(options =>
            {
                var connectionString = configuration["DB_CONNECTION_STRING"];
                options.UseNpgsql(connectionString);
            });
                
            return services;
        }
        
        private static IServiceCollection AddPersistenceRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            // Register every repository
            services.Scan(scan => scan
                .FromAssemblyOf<UnitOfWork>()
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            // Register UoW as scoped
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}