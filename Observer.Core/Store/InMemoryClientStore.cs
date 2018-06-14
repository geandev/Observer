using System.Collections.Generic;
using System.Threading.Tasks;

namespace Observer.Core.Store
{
    public class InMemoryClientStore : IClientStore
    {
        private readonly Dictionary<string, Models.Client> _clients;

        public InMemoryClientStore()
        {
            _clients = new Dictionary<string, Models.Client>();
        }

        public Task SaveAsync<TClient>(TClient client) where TClient : Models.Client
        {
            _clients.Add(client.Instance, client);
            return Task.CompletedTask;
        }

        public Task RemoveAsync<TClient>(TClient client) where TClient : Models.Client
        {
            _clients.Remove(client.Instance);
            return Task.CompletedTask;
        }
    }
}