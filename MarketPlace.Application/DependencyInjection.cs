using FluentValidation;
using MarketPlace.Application.Abstractions.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace MarketPlace.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(m =>
            {
                m.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                m.AddOpenBehavior(typeof(LoggingBehavior<,>));
                m.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            return services;
        }
    }
}
