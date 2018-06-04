using System.Collections.Generic;
using System.Threading.Tasks;
using Observer.Core.Client;

namespace Observer.Core.Store
{
    public class InMemoryClientStore : IClientStore
    {
        private readonly IList<IObservableClient> _clients;

        public InMemoryClientStore()
        {
            _clients = new List<IObservableClient>();
        }

        public Task SaveAsync<TClient>(TClient client) where TClient : IObservableClient
        {
            throw new System.NotImplementedException();
        }
    }
}
