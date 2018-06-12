using System;
using System.Collections.Generic;
using System.Linq;
using Observer.Core.Client;
using Observer.Core.Factories;
using Observer.Core.Server;

namespace Observer.Client
{
    public class ObservableClientBuilder : IObservableClientBuilder
    {
        public string Instance { get; private set; }
        public Uri Address { get; private set; }

        public readonly List<string> _observerServersAddress;
        public IEnumerable<IObserverServer> ObserverServers { get; private set; }

        public ObservableClientBuilder()
        {
            _observerServersAddress = new List<string>();
        }

        public IObservableClient Build(IObserverServerFactory observerServerFactory)
        {
            ObserverServers = _observerServersAddress.Select(observerServerFactory.FromAddress);
            return new ObservableClient(this);
        }

        public IObservableClientBuilder AddObserver(string observerAddress)
        {
            _observerServersAddress.Add(observerAddress);
            return this;
        }

        public IObservableClientBuilder WithOrigin(string originAddress)
        {
            Address = new Uri(originAddress);
            return this;
        }

        public IObservableClientBuilder WithInstanceName(string instanceName)
        {
            Instance = instanceName;
            return this;
        }
    }
}
