using challenge.emision.domain.Common;
using challenge.emision.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace challenge.emision.Integrations.Extensions
{
    public static class ExtensionsServices
    {
        public static IntegrationsContext? IntegrationsContext { get; set; }

        public static void DependencyInjections(this WebApplicationBuilder builder)
        {
            var integrationsContext = builder.Configuration.GetSection("IntegrationsContext").Get<IntegrationsContext>();
            IntegrationsContext = integrationsContext;

            builder.Services.AddSingleton(integrationsContext.GoogleBookConfiguration);

            //Dependency injecton
            builder.Services.AddGoogleDependencies();
        }
        public static void SwaggerConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GoogleIntegrations", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                    { Reference = new OpenApiReference
                    { Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"} },
                        new string[]
                        {
                        }
                    }
                });
            });
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

            //Token configuration
            if (IntegrationsContext.JwtOptions.Enabled)
            {
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(IntegrationsContext.JwtOptions.Key));
                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = IntegrationsContext.JwtOptions.Issuer,
                                ValidAudience = IntegrationsContext.JwtOptions.Audience,
                                IssuerSigningKey = signingKey
                            };
                        });
            }
        }
    }
}
