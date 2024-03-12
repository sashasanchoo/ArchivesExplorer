using ArchivesExplorer.Filters;
using ArchivexExplorer.Domain.Constants;
using ArchivexExplorer.Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace ArchivesExplorer.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void UseCustomCorsExtension(this WebApplication app)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
            );
        }

        public static void AddControllersExtensions(this IServiceCollection services)
        {
            services.AddControllers()
                .AddMvcOptions(options =>
                {
                    options.Filters.Add<RequestValidationFilter>();
                    options.Filters.Add<ExceptionFilter>();
                    options.Filters.Add<ResponseFilter>();
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters
                        .Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
        }

        public static void AddJwtAuthentication(this IServiceCollection services, TokenValidationParameters parameters)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationPolicyConstants.RefreshTokenPolicy, policy =>
                    policy.RequireClaim(ClaimConstants.AccessType, TokenAccessTypes.RefreshToken.ToString()));

                options.AddPolicy(AuthorizationPolicyConstants.AccessTokenPolicy, policy =>
                    policy.RequireClaim(ClaimConstants.AccessType, TokenAccessTypes.AccessToken.ToString()));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = parameters;
            });
        }
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "JWT Authentication",
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
