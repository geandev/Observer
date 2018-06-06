using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Observer.Core.Builders;
using Observer.Core.Client;
using Observer.Core.Factories;
using Observer.Core.Server;
using Microsoft.Extensions.DependencyInjection;

namespace Observer.Client
{
    public class ObservableClientBuilder : IObservableClientBuilder
    {
        private readonly IList<IObserverServer> _observerServers;
        private readonly IServiceProvider _serviceProvider;

        public string Instance { get; private set; }
        public string Address { get; private set; }
        public IEnumerable<IObserverServer> ObserverServers => _observerServers;

        private ObservableClientBuilder(string instance, IServiceProvider serviceProvider)
        {
            Instance = instance;
            _serviceProvider = serviceProvider;
        }

        public static IObservableClientBuilder Configure(string instance, IServiceProvider serviceProvider) => new ObservableClientBuilder(instance, serviceProvider);

        public IObservableClientBuilder AddObserver(string observerServerAddress)
        {
            _observerServers.Add(_serviceProvider.GetService<IObserverServerFactory>().FromAddress(observerServerAddress));
            return this;
        }

        public IObservableClient Build()
        {
            Address = GetAddressFromHttpContextAccessor(_serviceProvider.GetService<IHttpContextAccessor>()).ToString();
            return new ObservableClient(this);
        }

        private static Uri GetAddressFromHttpContextAccessor(IHttpContextAccessor accessor)
        {
            var request = accessor.HttpContext.Request;
            return new UriBuilder { Scheme = request.Scheme, Host = request.Host.ToString() }.Uri;
        }

    }
}
