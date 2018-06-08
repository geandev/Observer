using Microsoft.AspNetCore.Http;
using Observer.Core.Extensions;
using Observer.Core.Models;
using Observer.Core.Server;
using System.Threading.Tasks;

namespace Observer.Server
{
    public class ObserverServerDisconnectMiddleware
    {
        public ObserverServerDisconnectMiddleware(RequestDelegate next) { }

        public async Task Invoke(HttpContext context, IObserverServer server)
            => await server.DisconnectAsync(await context
                .DeserializeRequestBodyAsync<Client>()
                .ContinueWith(t => t.Result.SetAddressFromRequest(context)));
    }
}