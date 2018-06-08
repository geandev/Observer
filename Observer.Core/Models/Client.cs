using System;

namespace Observer.Core.Models
{
    public class Client
    {
        public string Instance { get; set; }
        public Uri Address { get; set; }
        public Uri PingEndpoint { get; set; }
        public Uri HealthEndpoint { get; set; }
        public bool Avaliable { get; set; }

        public Client() { }

        private Client(string instance, bool avaliable)
        {
            Instance = instance;
            Avaliable = avaliable;
        }

        public static Client FromOnline(string instance) => new Client(instance, true);
        public static Client FromOffiline(string instance) => new Client(instance, false);

        public void SetAddress(Uri address)
        {
            Address = address;
            PingEndpoint = new Uri(Address, Endpoints.Ping);
            HealthEndpoint = new Uri(Address, Endpoints.Health);
        }
    }
}
