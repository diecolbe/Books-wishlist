using challenge.emision.domain.Common;
using challenge.emision.Domain.Common;
using challenge.emision.EF;
using challenge.emision.GoogleIntegrations;
using challenge.emision.MongoDb;
using challenge.emision.presenters;
using challenge.emision.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace challenge.emision.IoC
{
    public static class DependencyContainers
    {
        public static IServiceCollection AddGoogleDependencies(this IServiceCollection services)
        {
            services.AddGoogleRepositories();
            services.AddGoogleUseCases();
            services.AddGooglePresenters();
            return services;
        }

        public static IServiceCollection AddSecurityDependencies(this IServiceCollection services,
           MongoDbSettings securitycontext)
        {
            services.AddMongoSecurity(securitycontext);
            services.AddSecurityUseCases();
            services.AddSecurityPresenters();
            return services;
        }

        public static IServiceCollection AddBooksWishlisDependencies(this IServiceCollection services,
           BookswishlistContext bookswishlistContext)
        {
            services.AddRepositoriesEF(bookswishlistContext);
            services.AddBooksWishListUseCases();
            services.AddBooksWishListPresenters();
            
            return services;
        }
    }
}
