using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Observer.Core.Store;

namespace Observer.Server
{
    public class ObserverServerHostedService : IHostedService
    {
        private readonly IClientStore _clientStore;

        public ObserverServerHostedService(IClientStore clientStore)
        {
            _clientStore = clientStore;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
