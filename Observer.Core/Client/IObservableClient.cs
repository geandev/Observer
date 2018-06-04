using Observer.Core.Server;
using System.Threading.Tasks;

namespace Observer.Core.Client
{
    public interface IObservableClient
    {
        string Instance { get; }
        string Address { get; }
        bool Avaliable { get; }

        Task NotifyClientUpAsync(params IObserverServer[] observerServers);
        Task NotifyClientDownAsync(params IObserverServer[] observerServers);
    }
}
