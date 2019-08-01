namespace ServiceLocatorFramework
{
    public interface IBindOptions<T>
    {
        IScopeOptions Implements<T1>() where T1 : T;
    }
}
