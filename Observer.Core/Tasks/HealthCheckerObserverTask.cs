using Observer.Core.Store;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Observer.Core.Tasks
{
    public class HealthCheckerObserverTask : IObserverTask
    {
        private readonly ILogger _logger;
        private readonly IClientStore _clientStore;
        private readonly HttpClient _httpClient;

        public HealthCheckerObserverTask(
            ILogger<HealthCheckerObserverTask> logger,
            IClientStore clientStore
            )
        {
            _logger = logger;
            _clientStore = clientStore;
            _httpClient = new HttpClient();
        }

        public async Task RunAsync()
        {
            foreach (var client in await _clientStore.GetAllAsync())
            {
                try
                {
                    _logger.LogInformation($"Ping instance: {client.Instance}, address: {client.PingEndpoint}");
                    var response = await _httpClient.GetAsync(client.PingEndpoint);
                    _logger.LogInformation($"Response from {client.Instance}: {await response.Content.ReadAsStringAsync()}");
                }
                catch (System.Exception)
                {
                    _logger.LogWarning($"Not Found instance: {client.Instance}");
                    await _clientStore.RemoveAsync(client);
                }
            }
        }

        public void Dispose() => _httpClient.Dispose();
    }
}
