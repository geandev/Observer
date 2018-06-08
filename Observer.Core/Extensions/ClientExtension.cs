using Microsoft.AspNetCore.Http;
using System;

namespace Observer.Core.Extensions
{
    public static class ClientExtension
    {
        public static Models.Client SetAddressFromRequest(this Models.Client client, HttpContext httpContext)
        {
            var connection = httpContext.Connection;
            var request = httpContext.Request;
            var address = new UriBuilder(request.Scheme, connection.RemoteIpAddress.ToString(), connection.RemotePort);
            client.SetAddress(address.Uri);
            return client;
        }

    }
}
