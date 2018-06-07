using Observer.Core.Server;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Observer.Core.Client
{
    public interface IObservableClient
    {
        string Instance { get; }
        string Address { get; }
        IEnumerable<IObserverServer> ObserverServers { get; }

        Task NotifyServerUnvaliable();
        Task NotifyServerAvaliable();
    }
}
