using Observer.Core.Server;

namespace Observer.Core.Factories
{
    public interface IObserverServerFactory
    {
        IObserverServer FromAddress(string address);
    }
}
