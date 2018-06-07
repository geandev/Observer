using Microsoft.AspNetCore.Http;
using Observer.Core.Server;
using System.Threading.Tasks;

namespace Observer.Server
{
    public class ObserverServerDiscoveryMiddleware
    {
        public ObserverServerDiscoveryMiddleware(RequestDelegate next) { }

        public Task Invoke(HttpContext context, IObserverServer server)
        {
            return Task.CompletedTask;
        }
    }
}
