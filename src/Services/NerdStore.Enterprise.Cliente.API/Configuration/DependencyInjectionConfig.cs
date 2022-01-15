using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Enterprise.Cliente.API.Application.Commands;
using NerdStore.Enterprise.Cliente.API.Application.Events;
using NerdStore.Enterprise.Cliente.API.Data;
using NerdStore.Enterprise.Cliente.API.Data.Repositories;
using NerdStore.Enterprise.Cliente.API.Models;
using NerdStore.Enterprise.Core.Mediatr;

namespace NerdStore.Enterprise.Cliente.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();

            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ClientesContext>();
        }
    }
}
