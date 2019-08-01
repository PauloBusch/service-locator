namespace ServiceLocatorFramework
{
    public interface IServiceLocator
    {
        T Get<T>();
        IBindOptions<T> Set<T>();
    }
}
