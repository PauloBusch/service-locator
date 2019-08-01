using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class Mock : IMock
    {
        public int Instances { get; private set; }

        private static int _instances;
        public Mock() {
            _instances++;
            Instances = _instances;
        }
    }
}
