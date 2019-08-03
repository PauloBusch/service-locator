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
            var bind = _binds.FirstOrDefault(b => b.InterfaceAreEqual(typeof(TInterface)));
            if (bind == null)
                throw new ImplementsException();

            return (TInterface)bind.GetInstance();
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
