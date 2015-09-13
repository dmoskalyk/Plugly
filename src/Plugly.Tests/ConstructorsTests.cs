using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plugly.Tests.Data;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Tests
{
    [TestClass]
    public class ConstructorsTests : TestsBase
    {
        [TestMethod]
        public void Constructors_Default()
        {
            var customer = customizer.CreateInstance<Customer>();
            customer.FirstName.ShouldBe("first");
            customer.LastName.ShouldBe("last");
        }

        [TestMethod]
        public void Constructors_Alternative()
        {
            var args = ConstructionParameters.FromValues("f", "l");
            var customer = customizer.CreateInstance<Customer>(args);
            customer.FirstName.ShouldBe("f");
            customer.LastName.ShouldBe("l");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructors_Missing()
        {
            var args = ConstructionParameters.FromValues("f", 1);
            var customer = customizer.CreateInstance<Customer>(args);
        }
    }
}
