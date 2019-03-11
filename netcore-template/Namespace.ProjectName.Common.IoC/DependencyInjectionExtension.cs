using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Namespace.ProjectName.Application.Implementation.Configuration;
using Namespace.ProjectName.Domain.Implementation.Configuration;
using Namespace.ProjectName.Persistence.Implementation.Configuration;

namespace Namespace.ProjectName.Common.IoC
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
//            services.AddPersistenceDependencies(configuration);
            services.AddApplicationDependencies(configuration);
            services.AddDomainDependencies(configuration);
            
            return services;
        }
    }
}