using Observer.Core.Store;

namespace Observer.Core.Builders
{
    public interface IObserverServerBuilder
    {
        IClientStore Storage { get; }

        IObserverServerBuilder ConfigureStorage(IClientStore store);
    }
}