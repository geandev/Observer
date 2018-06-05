using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Observer.Core.Builders;
using Observer.Core.Client;
using Observer.Core.Models;
using Observer.Core.Server;
using Observer.Core.Store;

namespace Observer.Server
{
    [ApiController]
    public class ObserverServer : IObserverServer
    {
        private readonly IClientStore _clientStore;

        protected ObserverServer(IObserverServerBuilder builder)
        {
        }

        [HttpPost(Endpoints.Connect)]
        public Task ConnectAsync<TObservable>(TObservable client) where TObservable : IObservableClient => _clientStore.SaveAsync(client);

        [HttpPost(Endpoints.Disconnect)]
        public Task DisconnectAsync<TObservable>(TObservable client) where TObservable : IObservableClient => _clientStore.SaveAsync(client);
    }
}
