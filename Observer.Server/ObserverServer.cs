using System.Threading.Tasks;
using Observer.Core.Client;
using Observer.Core.Server;
using Observer.Core.Store;

namespace Observer.Server
{
    public class ObserverServer : IObserverServer
    {
        private readonly IClientStore _clientStore;

        public ObserverServer(IObserverServerBuilder builder)
        {
            _clientStore = builder.Storage;
        }

        public Task ConnectAsync<TObservable>(TObservable client) where TObservable : IObservableClient => _clientStore.SaveAsync(client);

        public Task DisconnectAsync<TObservable>(TObservable client) where TObservable : IObservableClient => _clientStore.SaveAsync(client);
    }
}
