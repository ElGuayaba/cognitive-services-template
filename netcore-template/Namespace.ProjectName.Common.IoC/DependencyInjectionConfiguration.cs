using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Namespace.ProjectName.Common.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistenceDependencies(configuration);

            services.AddIdentity(configuration);
            
            return services;
        }
    }
}