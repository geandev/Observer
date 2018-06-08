using Observer.Core.Client;
using Observer.Core.Factories;
using Observer.Core.Server;
using System.Collections.Generic;

namespace Observer.Client
{
    public interface IObservableClientBuilder
    {
        string Instance { get; }

        IEnumerable<IObserverServer> ObserverServers { get; }

        IObservableClientBuilder AddObserver(string observerAddress);
        IObservableClient Build(IObserverServerFactory observerServerFactory);
    }
}
