using challenge.emision.ports.Output;
using challenge.emision.presenters.Books_wishlist;
using Microsoft.Extensions.DependencyInjection;

namespace challenge.emision.presenters
{
    public static class DependencyContainersBooksWishList
    {
        public static IServiceCollection AddBooksWishListPresenters(this IServiceCollection services)
        {
            services.AddScoped<ICreateBooksWishlistOutputPort, CreateBooksWishlistPresenter>();
            services.AddScoped<IAddBookToWishlistOutputPort, AddBooksToWishlistPresenter>();
            services.AddScoped<IDeleteBookToWishlistOutputPort, DeleteBooksToWishListPresenter>();
            services.AddScoped<IDeleteWishListOutputPort, DeleteWishlistUseCasePresenter>();

            return services;
        }
    }
}
