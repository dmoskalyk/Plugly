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
    public class MixinTests
    {
        Customizer customizer;

        [TestInitialize]
        public void TestInitialize()
        {
            customizer = new Customizer();
        }

        [TestMethod]
        public void ExtendWith_Single()
        {
            customizer.Setup<Address>()
                .ExtendWith<PhoneNumberExtension>();

            var address = customizer.CreateInstance<Address>();
            address.ShouldBeAssignableTo<IPhoneNumberExtension>();

            dynamic dyn = address;
            dyn.PhoneNumber = "my number";

            var ext = (IPhoneNumberExtension)address;
            ext.PhoneNumber.ShouldBe("my number");
        }

        [TestMethod]
        public void ExtendWith_Multiple()
        {
            customizer.Setup<Address>()
                .ExtendWith<PhoneNumberExtension>()
                .ExtendWith<StreetExtension>()
                ;

            var address = customizer.CreateInstance<Address>();
            address.ShouldBeAssignableTo<IPhoneNumberExtension>();
            address.ShouldBeAssignableTo<IStreetExtension>();
            dynamic dyn = address;
            dyn.PhoneNumber = "phone";
            dyn.Street = "street";
            address.GetText().ShouldBe("Imaginationland, South Park, phone, street");
        }

        class PhoneNumberExtension : IPhoneNumberExtension
        {
            public string PhoneNumber { get; set; }

            [Customization]
            static string GetText(Address address)
            {
                var ext = (IPhoneNumberExtension)address;
                return address.GetText() + ", " + ext.PhoneNumber;
            }
        }

        public interface IPhoneNumberExtension
        {
            string PhoneNumber { get; set; }
        }

        class StreetExtension : IStreetExtension
        {
            public string Street { get; set; }

            [Customization]
            static string GetText(Address address)
            {
                var ext = (IStreetExtension)address;
                return address.GetText() + ", " + ext.Street;
            }
        }

        public interface IStreetExtension
        {
            string Street { get; set; }
        }
    }
}
