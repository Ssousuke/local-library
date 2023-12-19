using LocalLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalLibrary.Infra.Data.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB() { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}
