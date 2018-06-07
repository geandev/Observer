using Microsoft.AspNetCore.Http;
using Observer.Core.Client;
using Observer.Core.Server;
using System.Threading.Tasks;

namespace Observer.Server
{
    public class ObserverServerDisconnectMiddleware
    {
        private readonly RequestDelegate _next;

        public ObserverServerDisconnectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IObserverServer server)
        {
            await server.DisconnectAsync(default(IObservableClient));
            await _next(httpContext);
        }
    }
}
