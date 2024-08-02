using LibrarySystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySystem.Application.DependencyInjection;

internal static class ServicesDependencyInjection
{
    internal static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<BookService>();
    }
}

