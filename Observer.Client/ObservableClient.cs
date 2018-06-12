using Observer.Core.Client;
using Observer.Core.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Observer.Client
{
    public class ObservableClient : IObservableClient
    {
        public IEnumerable<IObserverServer> ObserverServers { get; }

        public string Instance { get; }
        public Uri Address { get; }

        public ObservableClient(IObservableClientBuilder builder)
        {
            ObserverServers = builder.ObserverServers;
            Instance = builder.Instance;
            Address = builder.Address;
        }

        public async Task NotifyServerAvaliable()
            => await Task.WhenAll(ObserverServers.Select(s => s.ConnectAsync(Core.Models.Client.FromOnline(Instance, Address))));

        public async Task NotifyServerUnvaliable()
            => await Task.WhenAll(ObserverServers.Select(s => s.DisconnectAsync(Core.Models.Client.FromOffiline(Instance, Address))));
    }
}