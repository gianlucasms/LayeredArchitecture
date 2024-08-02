using LibrarySystem.Domain.Interfaces;
using LibrarySystem.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySystem.Application.DependencyInjection;

internal static class RepositoriesDependencyInjection
{
    internal static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
    }
}

