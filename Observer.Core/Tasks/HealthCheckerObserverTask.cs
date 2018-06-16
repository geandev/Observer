using Observer.Core.Store;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Observer.Core.Models;
using Observer.Core.Extensions;

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
                    _logger.LogInformation($"Ping instance: {client.Instance}, address: {client.HealthEndpoint}");
                    var response = await _httpClient.GetAsync(client.HealthEndpoint);
                    var responseString = await response.Content.ReadAsStringAsync();
                    var observableHealth = responseString.Deserialize<ObservableHealth>();

                    _logger.LogInformation($"Response from {client.Instance}: {observableHealth.Status}");
                }
                catch (System.Exception)
                {
                    _logger.LogWarning($"Not Found instance: {client.Instance}");
                }
            }
        }

        public void Dispose() => _httpClient.Dispose();
    }
}
