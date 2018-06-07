using Observer.Core.Client;
using System.Threading.Tasks;

namespace Observer.Core.Server
{
    public interface IObserverServer
    {
        Task ConnectAsync<TObservable>(TObservable client)
        where TObservable : Models.Client;

        Task DisconnectAsync<TObservable>(TObservable client)
        where TObservable : Models.Client;
    }
}
