namespace Observer.Core.Models
{
    public class Client
    {
        public string Instance { get; private set; }
        public string Address { get; private set; }
        public bool Avaliable { get; private set; }

        public Client() { }

        private Client(string instance, bool avaliable)
        {
            Instance = instance;
            Avaliable = avaliable;
        }

        public static Client FromOnline(string instance) => new Client(instance, true);
        public static Client FromOffiline(string instance) => new Client(instance, false);

        public void SetAddress(string address) => Address = address;
    }
}
