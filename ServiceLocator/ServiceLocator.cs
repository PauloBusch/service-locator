using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLocatorFramework
{
    public class ServiceLocator : IServiceLocator
    {
        private IList<IBindObject> _binds;
        public ServiceLocator() { 
            _binds = new List<IBindObject>();    
        }
        public TInterface Get<TInterface>()
        {
            var bind = _binds.FirstOrDefault(b => b.Interface == typeof(TInterface));
            if (bind == null)
                throw new ImplementsException();

            if (bind.Scope == EInstanceScope.SINGLETON) { 
                bind.SingletonInstance = bind.SingletonInstance ?? TryNewInstance(bind.Implements);
                return (TInterface)bind.SingletonInstance;
            }
            
            if (bind.Scope == EInstanceScope.NEW_INSTANCES)
                return (TInterface)TryNewInstance(bind.Implements);

            return default;
        }

        public IBindOptions<TInterface> Set<TInterface>()
        {
            var bind = new BindObject(){ Interface = typeof(TInterface) };
            _binds.Add(bind);
            return new BindOptions<TInterface>(bind);
        }
        private object TryNewInstance(Type type) {
            return Activator.CreateInstance(type);
        }
    }
}
