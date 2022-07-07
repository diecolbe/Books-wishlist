using challenge.emision.ports.Input.Security;
using challenge.emision.UseCases.Security;
using Microsoft.Extensions.DependencyInjection;

namespace challenge.emision.UseCases
{
    public static class DependencyContainersSecurity
    {
        public static IServiceCollection AddSecurityUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateUserInputPort, CreateUserUseCase>();
            services.AddTransient<IValidateUserInputPort, ValidateUserUseCase>();
            services.AddTransient<ILoginUserInputPort, LoginUserUseCase>();           

            return services;
        }
    }
}
