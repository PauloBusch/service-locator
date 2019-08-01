namespace ServiceLocatorFramework
{
    public interface IServiceLocator
    {
        IBindOptions Get<T>();
        IBindOptions Set<T>();
    }
}
