using Observer.Core.Server;
using Observer.Core.Store;

namespace Observer.Server
{
    public class ObserverServerBuilder : IObserverServerBuilder
    {
        public IClientStore Storage { get; private set; }

        public IObserverServerBuilder ConfigureStorage(IClientStore store)
        {
            Storage = store;
            return this;
        }

        public IObserverServer Build()
        {
            Storage = Storage ?? new InMemoryClientStore();
            return new ObserverServer(this);
        }
    }
}
