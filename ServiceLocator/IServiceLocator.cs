namespace ServiceLocatorFramework
{
    public interface IServiceLocator
    {
        TInterface Get<TInterface>();
        IBindOptions<TInterface> Set<TInterface>();
    }
}
