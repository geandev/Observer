using Observer.Core.Client;
using Observer.Core.Factories;
using Observer.Core.Server;
using System;
using System.Collections.Generic;

namespace Observer.Client
{
    public interface IObservableClientBuilder
    {
        string Instance { get; }
        Uri Address { get; }

        IEnumerable<IObserverServer> ObserverServers { get; }

        IObservableClientBuilder WithInstanceName(string instanceName);
        IObservableClientBuilder WithOrigin(string originAddress);
        IObservableClientBuilder AddObserver(string observerAddress);
        IObservableClient Build(IObserverServerFactory observerServerFactory);
    }
}
