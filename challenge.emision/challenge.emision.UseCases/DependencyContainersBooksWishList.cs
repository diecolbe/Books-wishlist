using challenge.emision.ports.Input;
using Microsoft.Extensions.DependencyInjection;

namespace challenge.emision.UseCases
{
    public static class DependencyContainersBooksWishList
    {
        public static IServiceCollection AddBooksWishListUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateBooksWishlistInputport, CreateBooksWishlistUseCase>();
            services.AddTransient<IAddBookToWishlistInputPort, AddBooksToWishListUseCase>();
            services.AddTransient<IDeleteBookToWishlistInputPort, DeleteBooksToWishListUseCase>();
            services.AddTransient<IDeleteWishListInputPort, DeleteWishlistUseCase>();

            return services;
        }
    }
}
