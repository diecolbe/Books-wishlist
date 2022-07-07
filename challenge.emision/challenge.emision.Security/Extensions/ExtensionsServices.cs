using challenge.emision.Domain.Common;
using challenge.emision.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace challenge.emision.Security.Extensions
{
    public static class ExtensionsServices
    {
        public static SecurityContext SecurityContext { get; set; }

        public static void DependencyInjections(this WebApplicationBuilder builder)
        {
            var securityContext = builder.Configuration.GetSection("SecurityContext").Get<SecurityContext>();
            SecurityContext = securityContext;

            builder.Services.AddSingleton(securityContext.MongoDbSettings);
            builder.Services.AddSingleton(securityContext.JwtOptions);

            //Dependency injecton
            builder.Services.AddSecurityDependencies(securityContext.MongoDbSettings);
        }

        public static void Jwt(this WebApplicationBuilder builder)
        {
            //Token configuration
            if (SecurityContext.JwtOptions.Enabled)
            {
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityContext.JwtOptions.Key));
                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = SecurityContext.JwtOptions.Issuer,
                                ValidAudience = SecurityContext.JwtOptions.Audience,
                                IssuerSigningKey = signingKey
                            };
                        });
            }
        }
    }
}
