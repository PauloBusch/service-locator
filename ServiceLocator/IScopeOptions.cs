using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocator
{
    public interface IScopeOptions
    {
        void SingletonScope();
        void NewInstancesScope();
    }
}
