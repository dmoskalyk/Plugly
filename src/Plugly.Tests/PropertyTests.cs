using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Plugly.Tests.Data;

namespace Plugly.Tests
{
    [TestClass]
    public class PropertyTests : TestsBase
    {
        [TestMethod]
        public void PropertyGetterOverride()
        {
            customizer.Setup<Address>()
                .OverrideGetter(a => a.Country, a => a.Country + ".")
                ;

            var address = customizer.CreateInstance<Address>();
            address.Country.ShouldBe("Imaginationland.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PropertyGetterOverride_InvalidExpression()
        {
            customizer.Setup<Address>()
                .OverrideGetter(a => a.GetText(), a => a.Country + "!")
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PropertyGetterOverride_NonVirtual()
        {
            customizer.Setup<Customer>()
                .OverrideGetter(c => c.FirstName, c => c.FirstName + "!")
                ;
        }

        [TestMethod]
        public void PropertySetterOverride()
        {
            customizer.Setup<Address>()
                .OverrideSetter(a => a.Country, (a, value) => a.Country = value + "!")
                ;

            var address = customizer.CreateInstance<Address>();
            address.Country.ShouldBe("Imaginationland!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PropertySetterOverride_InvalidExpression()
        {
            customizer.Setup<Address>()
                .OverrideSetter(a => a.GetText(), (a, value) => a.Country = value + "!")
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PropertySetterOverride_NonVirtual()
        {
            customizer.Setup<Customer>()
                .OverrideSetter(c => c.FirstName, (c, value) => c.FirstName = value + "!")
                ;
        }

        [TestMethod]
        public void PropertyOverride_UsingExtendWith()
        {
            customizer.Setup<Address>()
                .ExtendWith<AddressPropertyCustomization>()
                ;

            var address = customizer.CreateInstance<Address>();
            address.Country.ShouldBe("Imaginationland!");
            address.City.ShouldBe("South Park!");
        }

        class AddressPropertyCustomization
        {
            [Customization]
            static string get_Country(Address address)
            {
                return address.Country + "!";
            }

            [Customization]
            static void set_City(Address address, string value)
            {
                address.City = value + "!";
            }
        }
    }
}
