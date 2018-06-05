namespace Observer.Core.Builders
{
    public interface IObservableClientBuilder
    {
        IObservableClientBuilder InstanceName(string instanceName);
        IObservableClientBuilder AddObserver(string address);
    }
}
