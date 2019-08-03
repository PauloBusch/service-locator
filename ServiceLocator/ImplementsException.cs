using System;

namespace ServiceLocatorFramework
{
    public class ImplementsException : Exception
    {
        public override string Message => "Uma implementação não foi associada ao tipo solicitado";
    }
}
