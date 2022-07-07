using challenge.emision.domain.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace challenge.emision.Gateway.Extensions
{
    public static class ExtensionsServices
    {
        public static GatewayContext? GatewayContext { get; set; }

        public static void RegisterComponent(this WebApplicationBuilder builder)
        {
            builder.Host.UseContentRoot(Directory.GetCurrentDirectory())
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        config
                            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                            .AddJsonFile("appsettings.json", true, true)
                            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                            .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();
                    });

        }

        public static void DependencyInjections(this WebApplicationBuilder builder)
        {
            var gatewayContext = builder.Configuration.GetSection("GatewayContext").Get<GatewayContext>();
            GatewayContext = gatewayContext;

            builder.Services.AddSingleton(gatewayContext.JwtOptions);
        }

        public static void Authentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("DevCorsPolicy", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(GatewayContext.JwtOptions.Key));
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = GatewayContext.JwtOptions.Issuer,
                            ValidAudience = GatewayContext.JwtOptions.Audience,
                            IssuerSigningKey = signingKey
                        };
                    });

        }
    }
}
