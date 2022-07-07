using challenge.emision.ports.Output.GoogleBooks;
using challenge.emision.presenters.GoogleBooks;
using Microsoft.Extensions.DependencyInjection;

namespace challenge.emision.presenters
{
    public static class DependencyContainersGoogle
    {
        public static IServiceCollection AddGooglePresenters(this IServiceCollection services)
        {
            services.AddScoped<IGoogleSearchBookOutputPort, GoogleBooksPresenter>();
            return services;
        }
    }
}
