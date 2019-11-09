using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetcoreTemplate.Application.Implementation.Service;
using Scrutor;

namespace NetcoreTemplate.Api.WebApi.Configuration
{
    public static partial class DependencyInjectionExtension
    {
        private static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<UserService>()
                .AddClasses(classes =>
                    classes.Where(c => c.Name.EndsWith("Service")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            return services;
        }
    }
}