using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Observer.Server.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseIISIntegration()
                .UseUrls("http://::5001")
                .UseStartup<Startup>()
                .Build();
    }
}
