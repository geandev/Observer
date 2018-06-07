using System.Net.Http;
using System.Threading.Tasks;
using Observer.Core.Models;
using Observer.Core.Extensions;

namespace Observer.Core.Server
{
    public class HttpObserverServer : IObserverServer
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public HttpObserverServer(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        public Task ConnectAsync<TObservable>(TObservable client) where TObservable : Models.Client
            => _httpClient.PostAsync($"{_baseUrl}{Endpoints.Connect}", client.Serialize().ToStringContent());

        public Task DisconnectAsync<TObservable>(TObservable client) where TObservable : Models.Client
            => _httpClient.PostAsync($"{_baseUrl}{Endpoints.Disconnect}", client.Serialize().ToStringContent());
    }
}
