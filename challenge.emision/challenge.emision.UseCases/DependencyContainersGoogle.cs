using challenge.emision.ports.Input.GoogleBooks;
using challenge.emision.UseCases.GoogleIntegration;
using Microsoft.Extensions.DependencyInjection;

namespace challenge.emision.UseCases
{
    public static class DependencyContainersGoogle
    {
        public static IServiceCollection AddGoogleUseCases(this IServiceCollection services)
        {   
            services.AddTransient<IGoogleSearchBookInputPort, GoogleBooksUseCase>();

            return services;
        }
    }
}
