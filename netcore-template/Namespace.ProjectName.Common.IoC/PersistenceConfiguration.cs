using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Namespace.ProjectName.Persistence.Contract;
using Namespace.ProjectName.Persistence.Implementation;
using Namespace.ProjectName.Persistence.Implementation.Context;
using Scrutor;

namespace Namespace.ProjectName.Common.IoC
{
    public static class PersistenceConfiguration
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectNameDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSql"));
            });
            
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
        
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO
            return services;
        }
    }
}