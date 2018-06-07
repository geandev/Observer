using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Observer.Client.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddObservableClient("ClientSample",
                config => config
                .UseUrl("http://localhost:5000")
                .AddObserver("http://localhost:5001"));
        }

        public void Configure(IApplicationBuilder app)
        {
        }
    }
}
