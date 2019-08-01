using ServiceLocatorFramework;

namespace ServiceLocatorFramework
{
    public class BindOptions<TInterface> : IBindOptions<TInterface>
    {
        public IScopeOptions Implements<TImplements>() where TImplements : TInterface
        {
            throw new System.NotImplementedException();
        }
    }
}
