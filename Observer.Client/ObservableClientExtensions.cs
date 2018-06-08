using App.Metrics.AspNetCore.Health.Endpoints;
using App.Metrics.Health;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Observer.Core.Factories;
using Observer.Core.Models;
using System;

namespace Observer.Client
{
    public static class ObservableClientExtensions
    {
        public static void AddObservableClient(this IServiceCollection services, string instance, Func<IObservableClientBuilder, IObservableClientBuilder> setup)
        {
            services.AddSingleton(setup(new ObservableClientBuilder(instance)));
            services.AddSingleton<IHostedService, ObservableClientHostedService>();
            services.AddSingleton<IObserverServerFactory, ObserverServerFactory>();

            services.AddHealth(AppMetricsHealth
                .CreateDefaultBuilder()
                .HealthChecks
                .RegisterFromAssembly(services)
                .BuildAndAddTo(services));

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IConfigureOptions<HealthEndpointsHostingOptions>, ConfigureHealthHostingOptions>());
            services.AddHealthEndpoints();
        }

        public static void UseOservableClient(this IApplicationBuilder app)
        {
            app.UseHealthAllEndpoints();
        }

        public class ConfigureHealthHostingOptions : IConfigureOptions<HealthEndpointsHostingOptions>
        {
            public void Configure(HealthEndpointsHostingOptions options)
            {
                options.HealthEndpoint = Endpoints.Health;
                options.PingEndpoint = Endpoints.Ping;
            }
        }
    }
}