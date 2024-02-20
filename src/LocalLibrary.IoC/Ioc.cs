using LocalLibrary.Application.Mappings;
using LocalLibrary.Application.Services;
using LocalLibrary.Application.Services.IServices;
using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;
using LocalLibrary.Infra.Data.Context;
using LocalLibrary.Infra.Data.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LocalLibrary.IoC
{
    public static class Ioc
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<Author>), typeof(AuthorRepository));
            services.AddScoped(typeof(IGenericRepository<Book>), typeof(BookRepository));
            services.AddScoped(typeof(IGenericRepository<Genre>), typeof(GenreRepository));
            services.AddScoped(typeof(IGenericRepository<Language>), typeof(LanguageRepository));

            services.AddScoped<IAuthorServices, AuthorServices>();
            services.AddScoped<IBookServices, BookServices>();
            services.AddScoped<ILanguageServices, LanguageServices>();
            services.AddScoped<IGenreServices, GenreServices>();


            var myHandler = AppDomain.CurrentDomain.Load("LocalLibrary.Application");
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(myHandler));

            services.AddAutoMapper(typeof(ProfileMap));

            return services;

        }
    }
}
