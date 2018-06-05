using Observer.Core.Store;

namespace Observer.Core.Builders
{
    public interface IObserverServerBuilder
    {
        IObserverServerBuilder ConfigureStorage(IClientStore store);
    }
}