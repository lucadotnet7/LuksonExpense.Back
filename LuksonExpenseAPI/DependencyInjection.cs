using LuksonExpense.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace LuksonExpenseAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabaseConfiguration(services, configuration);
            EnableCORS(services);

            return services;
        }

        private static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(cfg =>
            {
                cfg.UseNpgsql(configuration.GetConnectionString("DatabaseConnection"));
            });
        }

        private static void EnableCORS(this IServiceCollection services)
        {
            services.AddCors(cfg =>
            {
                cfg.AddDefaultPolicy(builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }
    }
}
