using LocalLibrary.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocalLibrary.Db.SQLServer;

public static class SQLServerConfig
{
    public static IServiceCollection AddInfraestructureSQLServer(this IServiceCollection services, IConfiguration config)
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
        var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; User id=sa; Password={dbPassword}; TrustServerCertificate=true";
        services.AddDbContext<ContextDB>(options => options
                 .UseSqlServer(connectionString, x => x
       .MigrationsAssembly(typeof(ContextDB).Assembly.FullName)));

        return services;
    }
}