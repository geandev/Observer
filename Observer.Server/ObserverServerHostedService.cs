using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Observer.Core.Tasks;
using Observer.Core.Extensions;

namespace Observer.Server
{
    public class ObserverServerHostedService : IHostedService
    {
        private readonly HealthCheckerObserverTask _healthCheckerObserverTask;

        public ObserverServerHostedService(HealthCheckerObserverTask healthCheckerObserverTask)
        {
            _healthCheckerObserverTask = healthCheckerObserverTask;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                await _healthCheckerObserverTask
                    .RunAsync()
                    .Schedule();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
