using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class MockResolve : IMockResolve
    {
        public IMockInstances Mock { get; private set; }
        public MockResolve(IMockInstances mock)
        {
            Mock = mock;
        }
    }
}
