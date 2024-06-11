using etiqatest.Application.Common.Interfaces;
using etiqatest.Infrastructure.Common.Persistence;
using etiqatest.Infrastructure.Helper;
using etiqatest.Infrastructure.Persistence;
using etiqatest.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace etiqatest.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<CompleteDeveloperNetworkDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("CompleteDeveloperNetwork"), b => b.MigrationsAssembly("etiqatest.API")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
