using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class Mock : IMock
    {
        public int Instances { get => _instances; }

        private static int _instances;
        public Mock() {
            _instances++;
        }
    }
}
