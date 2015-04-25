using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plugly.Tests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Plugly.Tests
{
    [TestClass]
    public class InitializationTests
    {
        Customizer customizer;

        [TestInitialize]
        public void TestInitialize()
        {
            customizer = new Customizer();
        }

        [TestMethod]
        public void InitializeInstance_NoProxy()
        {
            customizer.Setup<Customer>()
                .InitializeWith(c => c.FirstName = "unnamed");
            
            var customer = new Customer();
            customizer.InitializeInstance(customer);
            customer.FirstName.ShouldBe("unnamed");
        }

        [TestMethod]
        public void InitializeInstance_WithProxy()
        {
            customizer.Setup<Customer>()
                .InitializeWith(c => c.FirstName = "unnamed");

            var customer = customizer.CreateInstance<Customer>();
            customer.FirstName.ShouldBe("unnamed");
        }

        [TestMethod]
        public void InitializeInstance_MultipleInitializers()
        {
            customizer.Setup<Customer>()
                .InitializeWith(c => c.FirstName = "unnamed")
                .InitializeWith(c => c.FirstName = c.FirstName.ToUpper())
                ;

            var customer = customizer.CreateInstance<Customer>();
            customer.FirstName.ShouldBe("UNNAMED");
        }

        [TestMethod]
        public void InitializeInstance_UsingExtendWith()
        {
            customizer.Setup<Address>()
                .ExtendWith<PhoneNumberExtension>()
                ;

            var address = customizer.CreateInstance<Address>();
            address.ShouldBeAssignableTo<IPhoneNumberExtension>();
            var ext = (IPhoneNumberExtension)address;
            ext.PhoneNumber.ShouldBe("unknown");
        }

        class PhoneNumberExtension : IPhoneNumberExtension
        {
            public string PhoneNumber { get; set; }

            [Customization]
            static void __init(Address address)
            {
                var ext = (IPhoneNumberExtension)address;
                ext.PhoneNumber = "unknown";
            }
        }

        public interface IPhoneNumberExtension
        {
            string PhoneNumber { get; set; }
        }
    }
}
