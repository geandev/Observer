using Observer.Core.Client;
using System.Threading.Tasks;

namespace Observer.Core.Server
{
    public interface IObserverServer
    {
        Task ConnectAsync<TObservable>(TObservable client)
        where TObservable : IObservableClient;

        Task DisconnectAsync<TObservable>(TObservable client)
        where TObservable : IObservableClient;
    }
}
