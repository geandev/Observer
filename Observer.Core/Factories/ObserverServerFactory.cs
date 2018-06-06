using Observer.Core.Server;

namespace Observer.Core.Factories
{
    public class ObserverServerFactory : IObserverServerFactory
    {
        public IObserverServer FromAddress(string address) => new HttpObserverServer(address);
    }
}
