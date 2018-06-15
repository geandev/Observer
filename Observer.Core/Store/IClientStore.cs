using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Observer.Core.Store
{
    public interface IClientStore : IDisposable
    {
        Task<ICollection<Models.Client>> GetAllAsync();

        Task SaveAsync(Models.Client client);

        Task RemoveAsync(Models.Client client);
    }
}
