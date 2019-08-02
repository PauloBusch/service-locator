using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocatorFramework
{
    public class ScopeOptions : IScopeOptions
    {
        private IBindObject _bind;
        public ScopeOptions(IBindObject bind) { 
            this._bind = bind;
        }
        public void NewInstancesScope()
        {
            _bind.Scope = EInstanceScope.NEW_INSTANCES;
        }

        public void SingletonScope()
        {
            _bind.Scope = EInstanceScope.SINGLETON;
        }
    }
}
