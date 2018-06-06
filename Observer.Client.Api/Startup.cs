using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Observer.Client.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddObservableClient();
        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IApplicationLifetime applicationLifetime)
        {
            app.UseObservableClient("SampleClient", serviceProvider)
                .AddObserver("http://localhost:8091").Build()
                .WithLifeTime(applicationLifetime);
        }
    }
}
