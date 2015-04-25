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
    public class CustomizationsTests
    {
        Customizer customizer;

        [TestInitialize]
        public void TestInitialize()
        {
            customizer = new Customizer();
        }

        [TestMethod]
        public void ExtendWith_Correct()
        {
            customizer.Setup<Customer>()
                .ExtendWith<CorrectCustomizations>()
                ;

            var customer = customizer.CreateInstance<Customer>();
            customer.FirstName = "John";
            customer.LastName = "Doe";
            customer.GetFullName("{0} {1}{2}").ShouldBe("John Doe!");
            var test = new Customer();
            customer.CopyTo(test, "ny");
            test.FirstName.ShouldBe("Johnny!");
        }

        [TestMethod]
        public void ExtendWith_CorrectStatic()
        {
            customizer.Setup<Customer>()
                .ExtendWith(typeof(CorrectStaticCustomizations))
                ;

            var customer = customizer.CreateInstance<Customer>();
            customer.FirstName = "John";
            customer.LastName = "Doe";
            customer.GetFullName("{0} {1}{2}").ShouldBe("John Doe!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExtendWith_NoAttribute()
        {
            customizer.Setup<Customer>()
                .ExtendWith<NoAttributeCustomizations>()
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExtendWith_NonStatic()
        {
            customizer.Setup<Customer>()
                .ExtendWith<NonStaticCustomizations>()
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExtendWith_InvalidFirstArgument()
        {
            customizer.Setup<Customer>()
                .ExtendWith<InvalidFirstArgumentCustomizations>()
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMethodException))]
        public void ExtendWith_MissingMethod()
        {
            customizer.Setup<Customer>()
                .ExtendWith<MissingMethodCustomizations>()
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMethodException))]
        public void ExtendWith_ArgumentCountMismatch()
        {
            customizer.Setup<Customer>()
                .ExtendWith<ArgumentCountMismatchCustomizations>()
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMethodException))]
        public void ExtendWith_ArgumentTypeMismatch()
        {
            customizer.Setup<Customer>()
                .ExtendWith<ArgumentTypeMismatchCustomizations>()
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMethodException))]
        public void ExtendWith_NonPublicTargetMethod()
        {
            customizer.Setup<Customer>()
                .ExtendWith<NonPublicTargetMethodCustomizations>()
                ;
        }

        class CorrectCustomizations
        {
            [Customization]
            public static string GetFullName(Customer customer, string format)
            {
                return customer.GetFullName(format) + "!";
            }

            [Customization]
            public static void CopyTo(Customer customer, Customer other, string suffix)
            {
                customer.CopyTo(other, suffix);
                other.FirstName += "!";
            }
        }

        static class CorrectStaticCustomizations
        {
            [Customization]
            public static string GetFullName(Customer customer, string format)
            {
                return customer.GetFullName(format) + "!";
            }
        }

        class NoAttributeCustomizations
        {
            public static string GetFullName(Customer customer, string format)
            {
                return customer.GetFullName(format) + "!";
            }
        }

        class NonStaticCustomizations
        {
            [Customization]
            public string GetFullName(Customer customer, string format)
            {
                return customer.GetFullName(format) + "!";
            }
        }

        class InvalidFirstArgumentCustomizations
        {
            [Customization]
            public static string GetFullName(string format)
            {
                return "!";
            }
        }

        class MissingMethodCustomizations
        {
            [Customization]
            public static string NonExistingMethod(Customer customer, string format)
            {
                return "!";
            }
        }

        class ArgumentCountMismatchCustomizations
        {
            [Customization]
            public static string GetFullName(Customer customer)
            {
                return "!";
            }
        }

        class ArgumentTypeMismatchCustomizations
        {
            [Customization]
            public static string GetFullName(Customer customer, int param)
            {
                return "!";
            }
        }

        class NonPublicTargetMethodCustomizations
        {
            [Customization]
            public static string GetMiddleName(Customer customer)
            {
                return "!";
            }
        }
    }
}
