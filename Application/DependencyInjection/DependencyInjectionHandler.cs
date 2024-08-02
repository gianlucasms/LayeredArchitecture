using LibrarySystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace LibrarySystem.Application.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("teste");

        services.AddDbContext<LibraryContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddRepositories();
        services.AddServices();
    }
}

