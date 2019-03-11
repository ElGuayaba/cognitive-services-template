using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Namespace.ProjectName.Application.Implementation.Service;
using Scrutor;

namespace Namespace.ProjectName.Application.Implementation.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<AuthorService>()
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Service")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            return services;
        }
    }
}