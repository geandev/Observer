using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Observer.Core.Builders;
using Observer.Core.Client;
using Observer.Core.Factories;
using System;

namespace Observer.Client
{
    public static class Startup
    {
        public static void AddObservableClient(this IServiceCollection services, string intanceName)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IObserverServerFactory, ObserverServerFactory>();
        }

        public static IObservableClientBuilder UseObservableClient(this IApplicationBuilder app, string instance, IServiceProvider provider)
            => ObservableClientBuilder.Configure(instance, provider);

        public static void ConfigureLifeTime(this IObservableClient app, IApplicationLifetime applicationLifetime)
        {
            applicationLifetime.ApplicationStarted.Register(() => app.NotifyServerAvaliable().GetAwaiter().GetResult());
            applicationLifetime.ApplicationStopping.Register(() => app.NotifyServerUnvaliable().GetAwaiter().GetResult());
        }
    }
}
