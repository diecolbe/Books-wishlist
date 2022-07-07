using challenge.emision.Domain.Common;
using challenge.emision.MongoDb.Interfaces;
using challenge.emision.MongoDb.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace challenge.emision.MongoDb
{
    public static class DependencyContainersSecurity
    {
        public static IServiceCollection AddMongoSecurity(this IServiceCollection services, MongoDbSettings context)
        {
            string? database = context.DatabaseName;
            string? connectionString = context.ConnectionString;

            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = connectionString;
                options.DatabaseName = database;
            });

            services.AddSingleton(serviceProvider =>
                   serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            return services;
        }
    }
}
