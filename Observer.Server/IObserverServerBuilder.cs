using Observer.Core.Server;
using Observer.Core.Store;

namespace Observer.Server
{
    public interface IObserverServerBuilder
    {
        IClientStore Storage { get; }

        IObserverServerBuilder ConfigureStorage(IClientStore store);

        IObserverServer Build();
    }
}