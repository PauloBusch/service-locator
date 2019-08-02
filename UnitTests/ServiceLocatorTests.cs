using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLocatorFramework;

namespace UnitTests
{
    [TestClass]
    public class ServiceLocatorTests
    {
        private static int TRY_INSTANCES = 10;
        private static int SINGLETON_INSTANCE = 1;

        [TestInitialize]
        public void Setup() { 
            Mock.ResetCountInstances();
        }

        [TestMethod]
        public void NewInstances()
        {
            IServiceLocator sl = new ServiceLocator();
            sl.Set<IMock>()
                .Implements<Mock>()
                .NewInstancesScope();

            IList<IMock> InstanceObjects = new List<IMock>();
            for (int i = 0; i < TRY_INSTANCES; i++)
                InstanceObjects.Add(sl.Get<IMock>());

            IList<IMock> distinctInstances = InstanceObjects.Distinct().ToList();
            Assert.AreEqual(TRY_INSTANCES, distinctInstances.Count);

            for (int i = 0; i < TRY_INSTANCES; i++)
                Assert.AreEqual(i + 1, InstanceObjects[i].Instances);
        }
        [TestMethod]
        public void SingletonInstances()
        {
            IServiceLocator sl = new ServiceLocator();
            sl.Set<IMock>()
                .Implements<Mock>()
                .SingletonScope();

            IList<IMock> InstanceObjects = new List<IMock>();
            for (int i = 0; i < TRY_INSTANCES; i++)
                InstanceObjects.Add(sl.Get<IMock>());

            IList<IMock> distinctInstances = InstanceObjects.Distinct().ToList();
            Assert.AreEqual(SINGLETON_INSTANCE, distinctInstances.Count);

            for (int i = 0; i < TRY_INSTANCES; i++)
                Assert.AreEqual(SINGLETON_INSTANCE, InstanceObjects[i].Instances);
        }
        [TestMethod]
        [ExpectedException(typeof(ImplementsException))]
        public void NoImplementsException() {
            IServiceLocator sl = new ServiceLocator();
            sl.Get<IMock>();
        }
    }
}
