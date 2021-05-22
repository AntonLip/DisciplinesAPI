using DisciplinesAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DisciplinesAPI
{
    public static class AddDatabaseExtention
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>(opts =>
               opts.UseSqlServer(GetConnectionString(configuration)));
        }

        private static string GetConnectionString(IConfiguration configuration)
        {
            bool isHome = bool.Parse(configuration["Place:IsHome"]);
            if (isHome)
            {
                return configuration["ConnectionString:Str"];
            }
            var dbServer = configuration["DbSettings:DbServer"];
            var dbPort = configuration["DbSettings:DbPort"];
            var dbUser = configuration["DbSettings:DbUser"];
            var dbPassword = configuration["DbSettings:DbPassword"];
            var database = configuration["DbSettings:Database"];
            return $"Server={dbServer},{dbPort};Database={database};User Id={dbUser};Password={dbPassword};";
        }
    }
}
