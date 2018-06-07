using System.Collections.Generic;
using System.Threading.Tasks;

namespace Observer.Core.Store
{
    public class InMemoryClientStore : IClientStore
    {
        private readonly IList<Models.Client> _clients;

        public InMemoryClientStore()
        {
            _clients = new List<Models.Client>();
        }

        public Task SaveAsync<TClient>(TClient client) where TClient : Models.Client
        {
            _clients.Add(client);
            return Task.CompletedTask;
        }
    }
}