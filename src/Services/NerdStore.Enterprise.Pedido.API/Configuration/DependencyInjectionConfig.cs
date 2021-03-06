using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Enterprise.Core.Mediatr;
using NerdStore.Enterprise.Pedido.API.Application.Commands;
using NerdStore.Enterprise.Pedido.API.Application.Events;
using NerdStore.Enterprise.Pedido.API.Application.Queries;
using NerdStore.Enterprise.Pedidos.Domain.Pedidos;
using NerdStore.Enterprise.Pedidos.Domain.Vouchers;
using NerdStore.Enterprise.Pedidos.Infra.Data;
using NerdStore.Enterprise.Pedidos.Infra.Data.Repository;
using NerdStore.Enterprise.Pedidos.Infra.Repository;
using NerdStore.Enterprise.WebAPI.Core.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Pedido.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            // Commands
            services.AddScoped<IRequestHandler<AdicionarPedidoCommand, ValidationResult>, PedidoCommandHandler>();

            //// Events
            services.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();

            //// Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();

            //// Data
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<PedidosContext>();
        }
    }
}
