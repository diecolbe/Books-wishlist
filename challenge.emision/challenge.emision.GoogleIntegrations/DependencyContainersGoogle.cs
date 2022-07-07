using challenge.emision.domain.Interfaces.Repositories;
using challenge.emision.GoogleIntegrations.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace challenge.emision.GoogleIntegrations
{
    public static class DependencyContainersGoogle
    {
        public static IServiceCollection AddGoogleRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGoogleBooksRepository, GoogleBooksRepository>();

            return services;
        }
    }
}