using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plugly.Tests.Data;
using Shouldly;

namespace Plugly.Tests
{
    [TestClass]
    public class MethodOverrideTests
    {
        Customizer customizer;

        [TestInitialize]
        public void TestInitialize()
        {
            customizer = new Customizer();
        }

        [TestMethod]
        public void MethodWithReturnValue_Default()
        {
            var customer = new Customer();
            customer.GetFullName("{0} {1}{2}").ShouldBe("first last");
        }

        [TestMethod]
        public void MethodWithReturnValue_Override()
        {
            customizer.Setup<Customer>()
                .Override<string, string>(c => c.GetFullName(string.Empty), (c, format) => string.Format(format, c.LastName, null, c.FirstName))
                ;

            var customer = customizer.CreateInstance<Customer>();
            customer.GetFullName("{0} {1}{2}").ShouldBe("last first");
        }

        [TestMethod]
        public void MethodWithReturnValue_OverrideWithBaseCall()
        {
            customizer.Setup<Customer>()
                .Override<string, string>(c => c.GetFullName(string.Empty), (c, format) => "Full name: " + c.GetFullName(format))
                ;

            var customer = customizer.CreateInstance<Customer>();
            customer.GetFullName("{0} {1}{2}").ShouldBe("Full name: first last");
        }

        [TestMethod]
        public void MethodWithReturnValue_OverrideTwice()
        {
            customizer.Setup<Customer>()
                .Override<string, string>(c => c.GetFullName(string.Empty), (c, format) => "Full name: " + c.GetFullName(format))
                .Override<string, string>(c => c.GetFullName(string.Empty), (c, format) => c.GetFullName(format).Replace("last", "Last"))
                ;

            var customer = customizer.CreateInstance<Customer>();
            customer.GetFullName("{0} {1}{2}").ShouldBe("Full name: first Last");
        }

        [TestMethod]
        public void VoidMethod_Default()
        {
            var customer = customizer.CreateInstance<Customer>();
            customer.FirstName = "f";
            customer.LastName = "l";

            var result = new Customer();
            customer.CopyTo(result, "1");

            result.FirstName.ShouldBe("f1");
            result.LastName.ShouldBe("l1");
        }

        [TestMethod]
        public void VoidMethod_Override()
        {
            customizer.Setup<Customer>()
                .Override<Customer, string>(c => c.CopyTo(null, null), (c, other, suffix) => c.CopyTo(other, suffix + "2"))
                ;

            var customer = customizer.CreateInstance<Customer>();
            customer.FirstName = "f";
            customer.LastName = "l";

            var result = new Customer();
            customer.CopyTo(result, "1");
            
            result.FirstName.ShouldBe("f12");
            result.LastName.ShouldBe("l12");
        }

        [TestMethod]
        public void VoidMethod_OverrideUntyped()
        {
            var test = new Customer();
            Action<Customer, Customer, string> customMethod = (o, other, suffix) =>
            {
                o.CopyTo(other, suffix + ".");
                other.FirstName = "pre:" + other.FirstName;
            };
            customizer.Setup<Customer>()
                .Override("CopyTo", customMethod);

            var customer = customizer.CreateInstance<Customer>();
            customer.FirstName = "copied";
            customer.CopyTo(test, "-suf");
            test.FirstName.ShouldBe("pre:copied-suf.");
        }

        [TestMethod]
        public void MethodWithReturnValue_OverrideUntyped()
        {
            Func<Customer, string, string> customMethod = (o, format) => "overridden:" + o.GetFullName(format);
            customizer.Setup<Customer>()
                .Override("GetFullName", customMethod);

            var customer = customizer.CreateInstance<Customer>();
            customer.GetFullName("{0}").ShouldBe("overridden:first");
        }

        [TestMethod]
        public void ProtectedMethod_Override()
        {
            ProtectedCustomerMethods.Customize(customizer.Setup<Customer>());

            var customer = customizer.CreateInstance<Customer>();
            customer.GetFullName("{0} {1}{2}").ShouldBe("first van last");
        }

        class ProtectedCustomerMethods : Customer
        {
            public static void Customize(Customizer<Customer> customizer)
            {
                customizer
                    .OverrideProtected<ProtectedCustomerMethods, string>(c => c.GetMiddleName(), c => "van " + c.GetMiddleName())
                    ;
            }
        }
    }
}
