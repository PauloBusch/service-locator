using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocatorFramework
{
    public class BindObject : IBindObject
    {
        public Type Interface { get; set; }
        public Type Implements { get; set; }
        public EInstanceScope Scope { get; set; }
        public object SingletonInstance { get; set; }
    }
}
