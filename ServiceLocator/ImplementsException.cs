using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocatorFramework
{
    public class ImplementsException : Exception
    {
        public override string Message => "Uma implementação não foi associada ao tipo solicitado";
    }
}
