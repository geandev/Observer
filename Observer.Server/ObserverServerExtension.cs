using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Observer.Core.Models;
using System;

namespace Observer.Server
{
    public static class ObserverServerExtension
    {
        public static void AddObserverServer(this IServiceCollection services, Func<IObserverServerBuilder, IObserverServerBuilder> setup = null)
        {
            var builder = new ObserverServerBuilder();
            services.AddSingleton((setup?.Invoke(builder) ?? builder).Build());
        }

        public static void UseObserverServer(this IApplicationBuilder app)
        {
            app.Map(Endpoints.Connect, ctx => ctx.UseMiddleware<ObserverServerConnectMiddleware>());
            app.Map(Endpoints.Disconnect, ctx => ctx.UseMiddleware<ObserverServerDisconnectMiddleware>());
            app.Map(Endpoints.Discovery, ctx => ctx.UseMiddleware<ObserverServerDiscoveryMiddleware>());
        }
    }
}
