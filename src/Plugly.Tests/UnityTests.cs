using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Microsoft.Practices.Unity;
using Plugly.Tests.Data;

namespace Plugly.Tests
{
    [TestClass]
    public class UnityTests : TestsBase
    {
        IUnityContainer unity;

        protected override void Initialize()
        {
            unity = new UnityContainer();
            unity.AddNewExtension<Plugly.Unity.Extension>();
        }

        [TestMethod]
        public void Unity_NoCustomizations()
        {
            unity.Resolve<Customer>().ShouldBeOfType<Customer>();
        }

        [TestMethod]
        public void Unity_NoCustomizations_CustomInitializer()
        {
            customizer.Setup<Customer>()
                .InitializeWith(c => c.FirstName = "custom");

            var customer = unity.Resolve<Customer>();
            customer.ShouldBeOfType<Customer>();
            customer.FirstName.ShouldBe("custom");
        }

        [TestMethod]
        public void Unity_WithMixin()
        {
            customizer.Setup<Customer>()
                .InitializeWith(c => c.FirstName = "custom")
                .ExtendWith<Mixin>();

            var customer = unity.Resolve<Customer>();
            customer.ShouldNotBeOfType<Customer>();
            customer.ShouldBeAssignableTo<IMixin>();
            customer.FirstName.ShouldBe("custom");
        }

        [TestMethod]
        public void Unity_CustomDerivedClass()
        {
            unity.RegisterType<Customer, ExtendedCustomer>();
            customizer.Setup<Customer>()
                .ExtendWith<Mixin>();

            var customer = unity.Resolve<Customer>();
            customer.ShouldNotBeOfType<Customer>();
            customer.ShouldBeAssignableTo<ExtendedCustomer>();
            customer.ShouldBeAssignableTo<IMixin>();
        }

        [TestMethod]
        public void Unity_CustomDerivedClass_RemapCustomizations()
        {
            customizer.Setup<Customer>()
                .ExtendWith<Mixin>();

            unity.RegisterType<Customer, ExtendedCustomer>(); // mixin should be remapped at this point
            
            var customer = unity.Resolve<Customer>();
            customer.ShouldNotBeOfType<Customer>();
            customer.ShouldBeAssignableTo<ExtendedCustomer>();
            customer.ShouldBeAssignableTo<IMixin>();
        }

        [TestMethod]
        public void Unity_NoBuildUp()
        {
            unity.RegisterType<Customer, ExtendedCustomer>();
            customizer.SetBuildUp(false)
                .Setup<Customer>()
                .ExtendWith<Mixin>();

            var customer = unity.Resolve<Customer>();
            customer.ShouldNotBeOfType<Customer>();
            customer.ShouldBeAssignableTo<ExtendedCustomer>();
            customer.ShouldBeAssignableTo<IMixin>();
            (customer as ExtendedCustomer).Unity.ShouldBe(null);
        }

        [TestMethod]
        public void Unity_BuildUp()
        {
            unity.RegisterType<Customer, ExtendedCustomer>();
            customizer
                .Setup<Customer>()
                .ExtendWith<Mixin>();

            var customer = unity.Resolve<Customer>();
            customer.ShouldNotBeOfType<Customer>();
            customer.ShouldBeAssignableTo<ExtendedCustomer>();
            customer.ShouldBeAssignableTo<IMixin>();
            (customer as ExtendedCustomer).Unity.ShouldBe(unity);
        }

        class Mixin : IMixin
        {
            public int MyProperty { get; set; }
        }

        public interface IMixin
        {
            int MyProperty { get; set; }
        }

        public class ExtendedCustomer : Customer
        {
            [Dependency]
            public IUnityContainer Unity { get; set; }
        }
    }
}
