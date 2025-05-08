using LuksonExpense.Application.DTOs.Profiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace LuksonExpense.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ModuleProfile).Assembly);

            services.AddMediatR(configuration =>
             {
                 configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
             });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
