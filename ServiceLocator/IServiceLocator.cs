using System;

namespace ServiceLocatorFramework
{
    public interface IServiceLocator
    {
        object Get(Type type);
        TInterface Get<TInterface>();
        IBindOptions<TInterface> Set<TInterface>(); 
        IScopeOptions Use<TClass>() where TClass : class;
    }
}
