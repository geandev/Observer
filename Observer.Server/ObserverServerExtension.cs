using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Observer.Core.Models;
using Observer.Core.Tasks;
using System;

namespace Observer.Server
{
    public static class ObserverServerExtension
    {
        public static void AddObserverServer(this IServiceCollection services, Func<IObserverServerBuilder, IObserverServerBuilder> setup = null)
        {
            var builder = new ObserverServerBuilder();
            services.AddLogging(config => config.AddConsole());
            services.AddSingleton((setup?.Invoke(builder) ?? builder).Build());
            services.AddSingleton(builder.Storage);
            services.AddSingleton<HealthCheckerObserverTask>();
            services.AddSingleton<IHostedService, ObserverServerHostedService>();
        }

        public static void UseObserverServer(this IApplicationBuilder app)
        {
            app.Map(Endpoints.Connect, ctx => ctx.UseMiddleware<ObserverServerConnectMiddleware>());
            app.Map(Endpoints.Disconnect, ctx => ctx.UseMiddleware<ObserverServerDisconnectMiddleware>());
            app.Map(Endpoints.Discovery, ctx => ctx.UseMiddleware<ObserverServerDiscoveryMiddleware>());
        }
    }
}
