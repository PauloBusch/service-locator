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
            var ctor = type.GetConstructors().FirstOrDefault();
            if (ctor != null) {
                var types = ctor.GetParameters().Select(p => p.ParameterType);
                if(!types.All(t => _binds.Any(b => b.Interface == t)))
                    throw new ImplementsException();

                var getMethod = typeof(ServiceLocator).GetMethod("Get");
                var instances = types.Select(t => getMethod.MakeGenericMethod(t).Invoke(this, null));
                return ctor.Invoke(instances.ToArray());
            }
            
            return Activator.CreateInstance(type);
        }
    }
}
