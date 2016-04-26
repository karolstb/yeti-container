using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions;
using Xunit.Sdk;
using Shouldly;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YeTi.Tests
{
    [TestClass]
    public class yeti_container_tests
    {
        [TestMethod]
        [Fact]
        public void resolves_registered_components()
        {
            //podobno komentarze są złe  lalala 2222
            //Arrange
            var container = new YeTiContainer();
            container.Register<ITestInterface, TestImplementation>();

            //Act
            var resolved_object = container.Resolve<ITestInterface>();

            //Assert
            resolved_object.ShouldBeOfType<TestImplementation>();
        }

        /// <summary>
        /// testowanie kontenera dla klas z konstruktorami z parametrem
        /// </summary
        [TestMethod]
        [Fact]
        public void resolves_components_with_ctor_with_params()
        {
            var container = new YeTiContainer();
            container.Register<Dependency, Dependency>();
            container.Register<ITestInterface, TestImplementationWithDependency>();
            
            var resolved_object = container.Resolve<ITestInterface>();
            
            resolved_object.ShouldBeOfType<TestImplementationWithDependency>();
        }

        public interface ITestInterface
        {


        }

        public class TestImplementation : ITestInterface
        {

        }

        public class Dependency
        {

        }

        public class TestImplementationWithDependency : ITestInterface
        {
            public TestImplementationWithDependency(Dependency dependency)
            {

            }
        }
    }
}
