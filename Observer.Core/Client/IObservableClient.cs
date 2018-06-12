using Observer.Core.Server;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Observer.Core.Client
{
    public interface IObservableClient
    {
        string Instance { get; }
        Uri Address { get; }

        IEnumerable<IObserverServer> ObserverServers { get; }

        Task NotifyServerUnvaliable();
        Task NotifyServerAvaliable();
    }
}
