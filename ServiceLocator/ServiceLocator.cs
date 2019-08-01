using System;

namespace ServiceLocatorFramework
{
    public class ServiceLocator : IServiceLocator
    {
        public T Get<T>()
        {
            throw new NotImplementedException();
        }

        public IBindOptions<T> Set<T>()
        {
            throw new NotImplementedException();
        }
    }
}
