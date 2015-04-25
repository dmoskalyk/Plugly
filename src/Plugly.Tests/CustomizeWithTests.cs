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
    public class CustomizeWithTests
    {
        Customizer customizer;

        [TestInitialize]
        public void TestInitialize()
        {
            customizer = new Customizer();
        }

        [TestMethod]
        public void CustomizeWith_Correct()
        {
            customizer.Setup<Customer>()
                .CustomizeWith<CorrectCustomizations>()
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
        [ExpectedException(typeof(ArgumentException))]
        public void CustomizeWith_NoAttribute()
        {
            customizer.Setup<Customer>()
                .CustomizeWith<NoAttributeCustomizations>()
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CustomizeWith_NonStatic()
        {
            customizer.Setup<Customer>()
                .CustomizeWith<NonStaticCustomizations>()
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CustomizeWith_InvalidFirstArgument()
        {
            customizer.Setup<Customer>()
                .CustomizeWith<InvalidFirstArgumentCustomizations>()
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMethodException))]
        public void CustomizeWith_MissingMethod()
        {
            customizer.Setup<Customer>()
                .CustomizeWith<MissingMethodCustomizations>()
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMethodException))]
        public void CustomizeWith_ArgumentCountMismatch()
        {
            customizer.Setup<Customer>()
                .CustomizeWith<ArgumentCountMismatchCustomizations>()
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMethodException))]
        public void CustomizeWith_ArgumentTypeMismatch()
        {
            customizer.Setup<Customer>()
                .CustomizeWith<ArgumentTypeMismatchCustomizations>()
                ;
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMethodException))]
        public void CustomizeWith_NonPublicTargetMethod()
        {
            customizer.Setup<Customer>()
                .CustomizeWith<NonPublicTargetMethodCustomizations>()
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
