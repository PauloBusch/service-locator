using System;

namespace ServiceLocatorFramework
{
    public interface IBindObject
    {
        Type Implements { get; set; }
        Type Interface { get; set; }
        EInstanceScope Scope { get; set; }
        object SingletonInstance { get; set; }
    }
    public enum EInstanceScope { 
        NEW_INSTANCES,
        SINGLETON
    }
}