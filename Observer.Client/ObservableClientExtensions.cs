using App.Metrics.AspNetCore.Health.Endpoints;
using App.Metrics.Health;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Observer.Core.Factories;
using System;

namespace Observer.Client
{
    public static partial class ObservableClientExtensions
    {
        public static void AddObservableClient(this IServiceCollection services, Func<IObservableClientBuilder, IObservableClientBuilder> setup)
        {
            services.AddSingleton(setup(new ObservableClientBuilder()));
            services.AddSingleton<IHostedService, ObservableClientHostedService>();
            services.AddSingleton<IObserverServerFactory, ObserverServerFactory>();
            services.AddObserverHealtEndpoints();
        }

        public static void UseOservableClient(this IApplicationBuilder app)
        {
            app.UseHealthAllEndpoints();
        }

        private static void AddObserverHealtEndpoints(this IServiceCollection services)
        {
            services.AddHealth(AppMetricsHealth
                .CreateDefaultBuilder()
                .HealthChecks
                .RegisterFromAssembly(services)
                .BuildAndAddTo(services));

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IConfigureOptions<HealthEndpointsHostingOptions>, ObservableClientHealthHostingOptions>());
            services.AddHealthEndpoints();
        }
    }
}