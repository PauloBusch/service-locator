namespace ServiceLocatorFramework
{
    public interface IBindOptions<TInterface>
    {
        IScopeOptions Implements<TImplements>() where TImplements : TInterface;
    }
}
