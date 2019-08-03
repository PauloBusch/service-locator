using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLocatorFramework
{
    public class BindObject : IBindObject
    {
        private Type _interface;
        private Type _implements;
        private EInstanceScope _scope;
        private object _singleton_instance;

        private IServiceLocator _service_locator;
        private IList<IBindObject> _binds;

        public BindObject(IServiceLocator serviceLocator, IList<IBindObject> binds) {
            this._scope = EInstanceScope.NEW_INSTANCES;
            this._service_locator = serviceLocator;
            this._binds = binds;
        }

        public object GetInstance()
        {
            if (_scope == EInstanceScope.SINGLETON)
            {
                _singleton_instance = _singleton_instance ?? TryNewInstance();
                return _singleton_instance;
            }

            if (_scope == EInstanceScope.NEW_INSTANCES)
                return TryNewInstance();

            return default;
        }

        private object TryNewInstance()
        {
            var ctor = _implements.GetConstructors().FirstOrDefault();
            if (ctor != null)
            {
                var types = ctor.GetParameters().Select(p => p.ParameterType);
                if (!types.All(t => _binds.Any(b => b.InterfaceAreEqual(t))))
                    throw new ImplementsException();

                var getMethod = typeof(ServiceLocator).GetMethod("Get");
                var instances = types.Select(t => getMethod.MakeGenericMethod(t).Invoke(_service_locator, null));
                return ctor.Invoke(instances.ToArray());
            }

            return Activator.CreateInstance(_implements);
        }

        public void Implements(Type type) => _implements = type;
        public void Interface(Type type) => _interface = type;
        public bool InterfaceAreEqual(Type type) => _interface == type;
        public void Scope(EInstanceScope scope) => _scope = scope;
    }
}
