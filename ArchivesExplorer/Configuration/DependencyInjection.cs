using ArchivesExplorer.Application.Helpers;
using ArchivesExplorer.Application.Services;
using ArchivesExplorer.DataContext;
using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivesExplorer.DataContext.Repositories.Interfaces.WriteRepositores;
using ArchivesExplorer.DataContext.Repositories.ReadRepositories;
using ArchivesExplorer.DataContext.Repositories.WriteRepositories;
using ArchivesExplorer.DataContext.UoW;
using ArchivesExplorer.Extensions;
using ArchivexExplorer.Core.Interfaces.Helpers;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Options;
using ArchivexExplorer.Domain.Resolvers;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Reflection;
using System.Text;

namespace ArchivesExplorer.Configuration
{
    public static class DependencyInjection
    {
        public static void AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArchivesExplorerDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DbConnection"),
                b => b.MigrationsAssembly("ArchivesExplorer.DataContext")));

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IRoleReadRepository, RoleReadRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IImagePathReadRepository, ImagePathReadRepository>();
            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IImagePathWriteRepository, ImagePathWriteRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IArchivexExplorerUnitOfWork, ArchivesExplorerUnitOfWork>();
        }

        public static void AddHelpers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddScoped<IFileManager, FileManager>();
            services.AddScoped<ITelegramNotificationSender, TelegramNotificationSender>();
            services.AddScoped<IOrderTelegramNotificationPreparer, OrderTelegramNotificationPreparer>();
            services.AddScoped<IMailNotificationSender, MailNotificationSender>();
            services.AddScoped<IOrderReceivedMailNotificationPreparer, OrderReceivedMailNotificationPreparer>();
            services.AddScoped<IMailMessageDeliveryService, MailMessageDeliveryService>();

            var clientOptions = configuration.GetSection(SmtpClientOptions.SectionName).Get<SmtpClientOptions>()!;
            services.AddSingleton<ISmtpClient, SmtpClientWrapper>(provider =>
            {
                var smtpClient = new SmtpClientWrapper(clientOptions.Host, clientOptions.Port)
                {
                    Credentials = new NetworkCredential(clientOptions.Username, clientOptions.Password),
                    EnableSsl = clientOptions.EnableSSL
                };

                return smtpClient;
            });
        }

        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IImagePathService, ImagePathService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderNotificationDeliveryService, OrderTelegramNotificationDeliveryService>();
        }

        public static void AddConfiguredAutoMapper(this IServiceCollection services)
        {
            var profileAssemblies = new[]
            {
                Assembly.GetAssembly(typeof(DataContext.MappingProfiles.MappingProfiles)),
                Assembly.GetAssembly(typeof(MappingProfiles.MappingProfiles))
            };

            services.AddAutoMapper(cfg =>
            {
                cfg.AddExpressionMapping();
            },
            profileAssemblies);
        }

        public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenOptions = configuration.GetSection(UserAuthTokenOptions.SectionName).Get<UserAuthTokenOptions>();

            services.AddJwtAuthentication(
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = tokenOptions?.Issuer,

                    ValidateAudience = true,
                    ValidAudience = tokenOptions?.Audience,

                    ValidateLifetime = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions?.Secret!)),
                    ValidateIssuerSigningKey = true,
                });
        }

        public static void AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<UserAuthTokenOptions>(configuration.GetSection(UserAuthTokenOptions.SectionName));
            services.Configure<FileManagerOptions>(configuration.GetSection(FileManagerOptions.SectionName));
            services.Configure<TelegramNotificationOptions>(configuration.GetSection(TelegramNotificationOptions.SectionName));
            services.Configure<NotificationPreparerOptions>(configuration.GetSection(NotificationPreparerOptions.SectionName));
            services.Configure<SmtpClientOptions>(configuration.GetSection(SmtpClientOptions.SectionName));
        }

        public static void AddExceptionResolvers(this IServiceCollection services)
        {
            services.AddScoped<IExceptionResolver, GlobalExceptionResolver>();
        }
    }
}
