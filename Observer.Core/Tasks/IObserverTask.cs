using System;
using System.Threading.Tasks;

namespace Observer.Core.Tasks
{
    public interface IObserverTask : IDisposable
    {
        Task RunAsync();
    }
}
