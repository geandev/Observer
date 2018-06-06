using Observer.Core.Store;

namespace Observer.Server
{
    public interface IObserverServerBuilder
    {
        IClientStore Storage { get; }

        IObserverServerBuilder ConfigureStorage(IClientStore store);
    }
}