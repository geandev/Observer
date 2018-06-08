using Microsoft.AspNetCore.Http;
using System;

namespace Observer.Core.Extensions
{
    public static class ClientExtension
    {
        public static Models.Client SetAddressFromRequest(this Models.Client client, HttpContext httpContext)
        {
            var request = httpContext.Request;
            var address = new UriBuilder(request.Scheme, request.Host.Host, request.Host.Port.Value);
            client.SetAddress(address.Uri);
            return client;
        }
    }
}
