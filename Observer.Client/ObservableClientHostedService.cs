using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Observer.Core.Client;
using Observer.Core.Factories;

namespace Observer.Client
{
    public class ObservableClientHostedService : IHostedService
    {
        private readonly IObservableClient _observableClient;
        private readonly IObserverServerFactory _observerServerFactory;

        public ObservableClientHostedService(
            IObservableClientBuilder observableClientBuilder,
            IObserverServerFactory observerServerFactory
            )
        {
            _observableClient = observableClientBuilder.Build(observerServerFactory);
            _observerServerFactory = observerServerFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _observableClient.NotifyServerAvaliable();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _observableClient.NotifyServerUnvaliable();
        }
    }
}
