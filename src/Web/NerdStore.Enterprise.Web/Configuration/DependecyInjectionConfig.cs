using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Enterprise.Web.Extensions;
using NerdStore.Enterprise.Web.Services;
using NerdStore.Enterprise.Web.Services.Handlers;
using NerdStore.Enterprise.WebAPI.Core.Usuario;
using Polly;
using Polly.Extensions.Http;
using System;

namespace NerdStore.Enterprise.Web.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            var retryWaitPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10)
                }, (outcome, timespan, retryCount, context) =>
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Tentando pela {retryCount} vez!");
                    Console.ForegroundColor = ConsoleColor.White;
                });

            services.AddHttpClient<ICatalogoService, CatalogoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                //.AddTransientHttpErrorPolicy(
                //    p => p.WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: _ => TimeSpan.FromMilliseconds(600)));
                .AddPolicyHandler(retryWaitPolicy)
                .AddTransientHttpErrorPolicy( p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            //services.AddHttpClient("Refit", options =>
            //{
            //    options.BaseAddress = new Uri(configuration.GetSection("CatalogoUrl").Value);
            //}).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //.AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddHttpClient<IComprasBffService, ComprasBffService>()
              .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
              .AddPolicyHandler(retryWaitPolicy)
              .AddTransientHttpErrorPolicy(
                  p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));


            services.AddHttpClient<IClienteService, ClienteService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddPolicyHandler(retryWaitPolicy)
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
        }
    }
}
