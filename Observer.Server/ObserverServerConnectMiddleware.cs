using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Observer.Core.Extensions;
using Observer.Core.Models;
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
            await server.ConnectAsync(await httpContext.DeserializeRequestBodyAsync<Client>());
            await _next(httpContext);
        }
    }
}
