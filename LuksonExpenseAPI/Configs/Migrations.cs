using LuksonExpense.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace LuksonExpenseAPI.Configs
{
    public static class Migrations
    {
        public static void RunMigrations(this WebApplication app) 
        {
            using IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

            using ApplicationDbContext context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();
        }
    }
}
