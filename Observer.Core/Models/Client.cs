using System;

namespace Observer.Core.Models
{
    public class Client
    {
        public string Instance { get; set; }
        public Uri Address { get; set; }
        public bool Avaliable { get; set; }

        public Uri PingEndpoint => new Uri(Address, Endpoints.Ping);
        public Uri HealthEndpoint => new Uri(Address, Endpoints.Health);

        public Client() { }

        private Client(string instance, Uri address, bool avaliable)
        {
            Instance = instance;
            Address = address;
            Avaliable = avaliable;
        }

        public static Client FromOnline(string instance, Uri address) => new Client(instance, address, true);
        public static Client FromOffiline(string instance, Uri address) => new Client(instance, address, false);
    }
}
