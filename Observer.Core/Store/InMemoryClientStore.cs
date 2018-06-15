using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Observer.Core.Store
{
    public class InMemoryClientStore : IClientStore
    {
        private readonly ConcurrentDictionary<string, Models.Client> _clients;

        public InMemoryClientStore()
        {
            _clients = new ConcurrentDictionary<string, Models.Client>();
        }

        public Task SaveAsync(Models.Client client)
        {
            _clients.TryAdd(client.Instance, client);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(Models.Client client)
        {
            _clients.TryRemove(client.Instance, out var c);
            return Task.CompletedTask;
        }

        public Task<ICollection<Models.Client>> GetAllAsync() => Task.FromResult(_clients.Values);

        public void Dispose() => _clients.Clear();
    }
}