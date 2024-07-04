using APIPersonCreate.Domain.Commands.v1;
using APIPersonCreate.Domain.Contracts.v1;
using APIPersonCreate.Domain.Pipes.v1;
using APIPersonCreate.Domain.Services.v1;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace APIPersonCreate.Domain
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDomainContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddAutoMapper(typeof(Bootstrapper))
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Bootstrapper)))
                .AddScoped<IDomainNotificationService, DomainNotificationServiceHandler>()
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidation<,>))
                .AddCommands()
                .AddValidators();
        }

        private static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddTransient<CreatePersonCommandHandler>();

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<CreatePersonCommand>, CreatePersonCommandValidator>();
            return services;
        }
    }
}
