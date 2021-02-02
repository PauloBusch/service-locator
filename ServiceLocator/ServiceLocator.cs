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
            var type = typeof(TInterface);
            return (TInterface)Get(type);
        }

        public object Get(Type type)
        {
            var bind = _binds.FirstOrDefault(b => b.InterfaceAreEqual(type));
            if (bind == null) throw new ImplementsException(type.Name);

            return bind.GetInstance();
        }

        public IBindOptions<TInterface> Set<TInterface>()
        {
            var bind = new BindObject(this, _binds);
            bind.Interface(typeof(TInterface));
            _binds.Add(bind);
            return new BindOptions<TInterface>(bind);
        }
    }
}
