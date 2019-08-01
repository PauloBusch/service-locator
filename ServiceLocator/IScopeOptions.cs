namespace ServiceLocatorFramework
{
    public interface IScopeOptions
    {
        void SingletonScope();
        void NewInstancesScope();
    }
}
