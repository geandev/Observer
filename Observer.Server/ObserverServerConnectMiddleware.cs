using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Observer.Core.Extensions;
using Observer.Core.Models;
using Observer.Core.Server;

namespace Observer.Server
{
    public class ObserverServerConnectMiddleware
    {
        public ObserverServerConnectMiddleware(RequestDelegate next) { }

        public async Task Invoke(HttpContext context, IObserverServer server)
            => await server.ConnectAsync(await context
                .DeserializeRequestBodyAsync<Client>()
                .ContinueWith(t => t.Result.SetAddressFromRequest(context)));
    }
}
