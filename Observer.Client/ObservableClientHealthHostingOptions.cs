using App.Metrics.AspNetCore.Health.Endpoints;
using Microsoft.Extensions.Options;
using Observer.Core.Models;

namespace Observer.Client
{
    public static partial class ObservableClientExtensions
    {
        public class ConfigureHealthHostingOptions : IConfigureOptions<HealthEndpointsHostingOptions>
        {
            public void Configure(HealthEndpointsHostingOptions options)
            {
                options.HealthEndpoint = Endpoints.Health;
                options.PingEndpoint = Endpoints.Ping;
            }
        }
    }
}