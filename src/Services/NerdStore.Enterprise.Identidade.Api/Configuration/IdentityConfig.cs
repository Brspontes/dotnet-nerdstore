using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Enterprise.Identidade.Api.Data;
using NerdStore.Enterprise.Identidade.Api.Extensions;
using NetDevPack.Security.JwtSigningCredentials;

namespace NerdStore.Enterprise.Identidade.Api.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppTokenSettings");
            services.Configure<AppTokenSettings>(appSettingsSection);   

            services.AddJwksManager(options => options.Algorithm = Algorithm.ES256)
                .PersistKeysToDatabaseStore<ApplicationDbContext>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
