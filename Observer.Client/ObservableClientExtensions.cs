using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Observer.Core.Factories;
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
        }
    }
}
