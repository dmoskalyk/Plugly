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
    public class ProtectedTests : TestsBase
    {
        [TestMethod]
        public void ProtectedMethod_OverrideFunc()
        {
            ProtectedCustomerExtension.Register(customizer.Setup<Customer>());

            var customer = customizer.CreateInstance<Customer>();
            customer.GetFullName("{0} {1}{2}").ShouldBe("first van _last");
        }

        [TestMethod]
        public void ProtectedMethod_OverrideAction()
        {
            ProtectedAddressExtension.Register(customizer.Setup<Address>());

            var address = customizer.CreateInstance<Address>();
            address.InvokeProtectedMethod();
            address.Country.ShouldBe("country1");
            address.City.ShouldBe("city2");
        }

        [TestMethod]
        public void ProtectedMethod_UsingExtendWith()
        {
            customizer.Setup<Customer>()
                .ExtendWith<ProtectedCustomerExtension>();

            var customer = customizer.CreateInstance<Customer>();
            customer.GetFullName("{0} {1} {2}").ShouldBe("first middle last");
        }

        [TestMethod]
        public void ProtectedMethod_UsingExtendWith_WithBaseMethod()
        {
            customizer.Setup<Customer>()
                .ExtendWith<ProtectedCustomerExtensionWithBaseMethod>();

            var customer = customizer.CreateInstance<Customer>();
            customer.GetFullName("{0} {1} {2}").ShouldBe("first mid_dle last");
        }

        class ProtectedCustomerExtension : Customer
        {
            public static void Register(Customizer<Customer> customizer)
            {
                customizer
                    .OverrideProtected<ProtectedCustomerExtension, string>(c => c.GetMiddleName(), c => "van " + c.GetMiddleName())
                    ;
            }

            [Customization]
            static string GetMiddleName(Customer customer)
            {
                return "middle";
            }
        }

        class ProtectedCustomerExtensionWithBaseMethod
        {
            [Customization]
            static string GetMiddleName(Customer customer, Func<string> baseMethod)
            {
                return "mid" + baseMethod() + "dle";
            }
        }

        class ProtectedAddressExtension : Address
        {
            public static void Register(Customizer<Address> customizer)
            {
                customizer
                    .OverrideProtected<ProtectedAddressExtension, string, string>(
                        method: a => a.SetValues(null, null), 
                        with: (a, country, city) => a.SetValues(country + "1", city + "2"))
                    ;
            }
        }
    }
}
