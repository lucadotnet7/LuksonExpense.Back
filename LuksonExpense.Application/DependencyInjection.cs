using LuksonExpense.Application.DTOs.Profiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using LuksonExpense.Application.Abstractions.Behaviors;
using LuksonExpense.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Identity;

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
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            services.AddScoped<PasswordHasher<object>>();
            services.AddScoped<AuthProvider>();
            services.AddScoped<PwdHasher>();
            return services;
        }
    }
}
