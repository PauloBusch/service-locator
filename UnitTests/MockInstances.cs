using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class MockInstances : IMockInstances
    {
        public int Instances { get; private set; }

        private static int _instances;
        public MockInstances() {
            _instances++;
            Instances = _instances;
        }

        public static void ResetCountInstances()
        {
            _instances = 0;
        }
    }
}
