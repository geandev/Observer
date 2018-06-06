using Observer.Core.Builders;
using Observer.Core.Client;
using Observer.Core.Server;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Observer.Client
{
    public class ObservableClient : IObservableClient
    {
        public string Instance { get; private set; }
        public string Address { get; private set; }
        public bool Avaliable { get; private set; }
        public IEnumerable<IObserverServer> ObserverServers { get; }

        public ObservableClient(IObservableClientBuilder builder)
        {
            Instance = builder.Instance;
            Address = builder.Address;
            ObserverServers = builder.ObserverServers;
        }

        public async Task NotifyServerUnvaliable()
        {
            Avaliable = true;
            await Task.WhenAll(ObserverServers.Select(s => s.ConnectAsync(this)));
        }

        public async Task NotifyServerAvaliable()
        {
            Avaliable = false;
            await Task.WhenAll(ObserverServers.Select(s => s.ConnectAsync(this)));
        }
    }
}