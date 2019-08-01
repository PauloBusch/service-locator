using System;

namespace ServiceLocatorFramework
{
    public class ServiceLocator : IServiceLocator
    {
        public IBindOptions Get<T>()
        {
            throw new NotImplementedException();
        }

        public IBindOptions Set<T>()
        {
            throw new NotImplementedException();
        }
    }
}
