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
            //Arrange
            var container = new YeTiContainer();
            container.Register<ITestInterface, TestImplementation>();

            //Act
            var resolved_object = container.Resolve<ITestInterface>();

            //Assert
            resolved_object.ShouldBeOfType<TestImplementation>();
        }

        public interface ITestInterface
        {


        }

        public class TestImplementation : ITestInterface
        {

        }
    }
}
