using System;
using System.Threading.Tasks;

namespace Observer.Core.Extensions
{
    public static class TaskExtension
    {
        public async static Task Schedule(this Task task, int seconds = 5)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
            await task;
        }
    }
}
