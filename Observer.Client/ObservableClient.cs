using Observer.Core.Client;
using Observer.Core.Server;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Observer.Client
{
    public class ObservableClient : IObservableClient
    {
        public IEnumerable<IObserverServer> ObserverServers { get; }

        public Core.Models.Client Info { get; private set; }

        public string Instance { get; }

        public ObservableClient(IObservableClientBuilder builder)
        {
            Instance = builder.Instance;
            ObserverServers = builder.ObserverServers;
        }

        public async Task NotifyServerAvaliable()
            => await Task.WhenAll(ObserverServers.Select(s => s.ConnectAsync(Core.Models.Client.FromOnline(Instance))));

        public async Task NotifyServerUnvaliable()
            => await Task.WhenAll(ObserverServers.Select(s => s.DisconnectAsync(Core.Models.Client.FromOffiline(Instance))));
    }
}