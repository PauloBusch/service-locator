using System;

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
