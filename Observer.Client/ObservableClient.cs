using Observer.Core.Builders;
using Observer.Core.Client;
using Observer.Core.Server;
using System.Linq;
using System.Threading.Tasks;

namespace Observer.Client
{
    public class ObservableClient : IObservableClient
    {
        public string Instance { get; private set; }
        public string Address { get; private set; }
        public bool Avaliable { get; private set; }

        public ObservableClient(IObservableClientBuilder builder)
        {
        }

        public Task NotifyClientUpAsync(params IObserverServer[] observerServers) => Task.WhenAll(observerServers.Select(o => o.ConnectAsync(this)));

        public Task NotifyClientDownAsync(params IObserverServer[] observerServers) => Task.WhenAll(observerServers.Select(o => o.DisconnectAsync(this)));
    }
}