using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Observer.Core.Client;
using Observer.Core.Server;

namespace Observer.Server
{
    public class ObserverServerConnectMiddleware
    {
        private readonly RequestDelegate _next;

        public ObserverServerConnectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IObserverServer server)
        {
            await server.ConnectAsync(default(IObservableClient));
            await _next(httpContext);
        }
    }
}
