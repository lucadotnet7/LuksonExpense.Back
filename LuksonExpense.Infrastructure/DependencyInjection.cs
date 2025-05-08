using LuksonExpense.Infrastructure.Interfaces;
using LuksonExpense.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LuksonExpense.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IModuleRepository, ModuleRepository>();
        }

        
    }
}
