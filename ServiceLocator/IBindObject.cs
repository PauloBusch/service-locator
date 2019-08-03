using System;
using System.Collections.Generic;

namespace ServiceLocatorFramework
{
    public interface IBindObject
    {
        void Implements(Type type);
        void Interface(Type type);
        void Scope(EInstanceScope scope);
        bool InterfaceAreEqual(Type type);
        object GetInstance();
    }
    public enum EInstanceScope { 
        NEW_INSTANCES,
        SINGLETON
    }
}