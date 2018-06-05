using System.Net.Http;
using System.Threading.Tasks;
using Observer.Core.Client;
using Observer.Core.Models;
using Newtonsoft.Json;

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

        public Task ConnectAsync<TObservable>(TObservable client) where TObservable : IObservableClient
        {
            return _httpClient.PostAsync($"{_baseUrl}/{Endpoints.Connect}", new StringContent(JsonConvert.SerializeObject(client)));
        }

        public Task DisconnectAsync<TObservable>(TObservable client) where TObservable : IObservableClient
        {
            return _httpClient.PostAsync($"{_baseUrl}/{Endpoints.Disconnect}", new StringContent(JsonConvert.SerializeObject(client)));
        }
    }
}
