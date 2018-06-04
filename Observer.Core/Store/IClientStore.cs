using Observer.Core.Client;
using System.Threading.Tasks;

namespace Observer.Core.Store
{
    public interface IClientStore
    {
        Task SaveAsync<TClient>(TClient client)
        where TClient : IObservableClient;
    }
}
