using App.Metrics.AspNetCore.Health.Endpoints;
using App.Metrics.Health;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Observer.Core.Factories;
using System;
using System.Reflection;

namespace Observer.Client
{
    public static partial class ObservableClientExtensions
    {
        public static void AddObservableClient(this IServiceCollection services, string instance, Func<IObservableClientBuilder, IObservableClientBuilder> setup)
        {
            services.AddSingleton(setup(new ObservableClientBuilder(instance)));
            services.AddSingleton<IHostedService, ObservableClientHostedService>();
            services.AddSingleton<IObserverServerFactory, ObserverServerFactory>();
            services.AddObserverHealtEndpoints();
        }

        public static void AddObservableClient(this IServiceCollection services, string observableAddress)
        {
            var callerAssemblyName = Assembly.GetEntryAssembly().GetName().Name;
            services.AddObservableClient(callerAssemblyName, config => config.AddObserver(observableAddress));
        }

        public static void UseOservableClient(this IApplicationBuilder app)
        {
            app.UseHealthAllEndpoints();
            app.Use(async (ctx, next) =>
            {
                await next();
            });
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