using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocator
{
    public interface IBindOptions
    {
        IScopeOptions Implements<T>();
    }
}
