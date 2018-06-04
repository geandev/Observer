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

        public ObservableClient(string instace, string address, bool avaliable)
        {
            Instance = instace;
            Address = address;
            Avaliable = avaliable;
        }

        public Task NotifyClientUpAsync(params IObserverServer[] observerServers) => Task.WhenAll(observerServers.Select(o => o.ConnectAsync(this)));

        public Task NotifyClientDownAsync(params IObserverServer[] observerServers) => Task.WhenAll(observerServers.Select(o => o.DisconnectAsync(this)));
    }
}