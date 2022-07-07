using challenge.emision.domain.Common;
using challenge.emision.domain.Interfaces.Repositories;
using challenge.emision.domain.Interfaces.RepositoryPattern;
using challenge.emision.EF.Context;
using challenge.emision.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace challenge.emision.EF
{
    public static class DependencyContainers
    {
        public static IServiceCollection AddRepositoriesEF(
            this IServiceCollection services,
            BookswishlistContext settings)
        {
            var provider = settings.DataBaseConfigurations.Provider;
            var connectionString = settings.DataBaseConfigurations.ConnectionString;

            switch (provider)
            {
                case "MySql":
                    services.AddDbContext<BookswishlistDbContext>(options =>
                   options.UseMySQL(connectionString));
                    break;
                default:
                    break;
            }

            services.AddScoped<DbContext, BookswishlistDbContext>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            //Repositories
            services.AddScoped<ICreateBooksWishlistRepository, CreateBooksWishlistRepository>();
            services.AddScoped<IDeleteBooksWishlistRepository, DeleteWishlistRepository>();
            services.AddScoped<IAddBooksToWishlistRepository, AddBookToWishlistRepository>();
            services.AddScoped<IDeleteBooksToWishlistRepository, DeleteBookToWishlistRepository>();            

            return services;
        }
    }
}
