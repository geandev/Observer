namespace Observer.Core.Models
{
    public class Client
    {
        public string Instance { get; set; }
        public string Address { get; set; }
        public bool Avaliable { get; set; }

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
