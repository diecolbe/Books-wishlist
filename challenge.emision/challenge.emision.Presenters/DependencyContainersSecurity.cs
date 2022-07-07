using challenge.emision.ports.Output.Security;
using challenge.emision.presenters.Security;
using Microsoft.Extensions.DependencyInjection;

namespace challenge.emision.presenters
{
    public static class DependencyContainersSecurity
    {
        public static IServiceCollection AddSecurityPresenters(this IServiceCollection services)
        {
            services.AddScoped<ICreateUserOuputPort, CreateUserPresenter>();
            services.AddScoped<IValidateUserOutputPort, ValidateUserPresenter>();
            services.AddScoped<ILoginUserOutputPort, LoginUserPresenter>();
            return services;
        }
    }
}
