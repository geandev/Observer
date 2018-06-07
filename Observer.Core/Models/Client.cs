namespace Observer.Core.Models
{
    public class Client
    {
        public string Instance { get; }
        public string Address { get; }
        public bool Avaliable { get; }

        public Client() { }

        private Client(string instance, string address, bool avaliable)
        {
            Instance = instance;
            Address = address;
            Avaliable = avaliable;
        }

        public static Client FromOnline(string instance, string address) => new Client(instance, address, true);
        public static Client FromOffiline(string instance, string address) => new Client(instance, address, false);
    }
}
