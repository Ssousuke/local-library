using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Mappings;
using LocalLibrary.Application.Services;
using LocalLibrary.Application.Services.IServices;
using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;
using LocalLibrary.Infra.Data.Context;
using LocalLibrary.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocalLibrary.IoC
{
    public static class Ioc
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

            services.AddScoped(typeof(IGenericServices<AuthorDTO>), typeof(AuthorServices));
            services.AddScoped(typeof(IGenericServices<BookDTO>), typeof(BookServices));
            services.AddScoped(typeof(IGenericServices<GenreDTO>), typeof(GenreServices));
            services.AddScoped(typeof(IGenericServices<LanguageDTO>), typeof(LanguageServices));

            services.AddAutoMapper(typeof(ProfileMap));

            return services;

        }
    }
}
