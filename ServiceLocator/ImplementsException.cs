using System;

namespace ServiceLocatorFramework
{
    public class ImplementsException : Exception
    {
        private readonly string _typeName;

        public ImplementsException(string typeName)
        {
            _typeName = typeName;
        }

        public override string Message => $"Uma implementação não foi associada ao tipo: {_typeName}";
    }
}
