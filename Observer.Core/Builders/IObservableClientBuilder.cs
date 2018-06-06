using Observer.Core.Client;
using Observer.Core.Server;
using System.Collections.Generic;

namespace Observer.Core.Builders
{
    public interface IObservableClientBuilder
    {
        string Instance { get; }
        string Address { get; }
        IEnumerable<IObserverServer> ObserverServers { get; }

        IObservableClientBuilder AddObserver(string observerServerAddress);
        IObservableClient Build();
    }
}
