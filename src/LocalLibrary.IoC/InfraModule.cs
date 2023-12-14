using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;
using LocalLibrary.Infra.Data.ContextDB;
using LocalLibrary.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocalLibrary.IoC
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ContextDB>(options => options
               .UseSqlServer(config.GetConnectionString("Dev"), x => x
                   .MigrationsAssembly(typeof(ContextDB).Assembly.FullName)));

            services.AddScoped(typeof(IGenericRepository<Author>), typeof(AuthorRepository));
            services.AddScoped(typeof(IGenericRepository<Book>), typeof(BookRepository));
            services.AddScoped(typeof(IGenericRepository<Genre>), typeof(GenreRepository));
            services.AddScoped(typeof(IGenericRepository<Language>), typeof(LanguageRepository));

            return services;

        }
    }
}
