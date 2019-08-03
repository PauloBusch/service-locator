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
            MockInstances.ResetCountInstances();
        }

        [TestMethod]
        public void NewInstances()
        {
            IServiceLocator sl = new ServiceLocator();
            sl.Set<IMockInstances>()
                .Implements<MockInstances>()
                .NewInstancesScope();

            IList<IMockInstances> InstanceObjects = new List<IMockInstances>();
            for (int i = 0; i < TRY_INSTANCES; i++)
                InstanceObjects.Add(sl.Get<IMockInstances>());

            IList<IMockInstances> distinctInstances = InstanceObjects.Distinct().ToList();
            Assert.AreEqual(TRY_INSTANCES, distinctInstances.Count);

            for (int i = 0; i < TRY_INSTANCES; i++)
                Assert.AreEqual(i + 1, InstanceObjects[i].Instances);
        }
        [TestMethod]
        public void SingletonInstances()
        {
            IServiceLocator sl = new ServiceLocator();
            sl.Set<IMockInstances>()
                .Implements<MockInstances>()
                .SingletonScope();

            IList<IMockInstances> InstanceObjects = new List<IMockInstances>();
            for (int i = 0; i < TRY_INSTANCES; i++)
                InstanceObjects.Add(sl.Get<IMockInstances>());

            IList<IMockInstances> distinctInstances = InstanceObjects.Distinct().ToList();
            Assert.AreEqual(SINGLETON_INSTANCE, distinctInstances.Count);

            for (int i = 0; i < TRY_INSTANCES; i++)
                Assert.AreEqual(SINGLETON_INSTANCE, InstanceObjects[i].Instances);
        }
        [TestMethod]
        public void ConstructorResolve() {
            IServiceLocator sl = new ServiceLocator();
            sl.Set<IMockInstances>()
                .Implements<MockInstances>()
                .SingletonScope();

            sl.Set<IMockResolve>()
                .Implements<MockResolve>()
                .SingletonScope();

            var singleton = sl.Get<IMockInstances>();
            var resolved = sl.Get<IMockResolve>();

            Assert.IsInstanceOfType(singleton, typeof(MockInstances));
            Assert.IsInstanceOfType(resolved.Mock, typeof(MockInstances));

            Assert.AreEqual(singleton, resolved.Mock);
            Assert.AreEqual(singleton.Instances, resolved.Mock.Instances);
        }
        [TestMethod]
        [ExpectedException(typeof(ImplementsException))]
        public void NoImplementsException() {
            IServiceLocator sl = new ServiceLocator();
            sl.Get<IMockInstances>();
        }
    }
}
