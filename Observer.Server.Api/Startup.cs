using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Observer.Server.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddObserverServer();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseObserverServer();
        }
    }
}
