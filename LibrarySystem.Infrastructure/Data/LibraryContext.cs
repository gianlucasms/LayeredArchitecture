using LibrarySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace LibrarySystem.Infrastructure.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
}

