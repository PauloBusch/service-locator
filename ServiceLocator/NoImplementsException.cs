using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocator
{
    public class NoImplementsException : Exception
    {
        public override string Message => "Uma implementação não foi associada ao tipo solicitado";
    }
}
