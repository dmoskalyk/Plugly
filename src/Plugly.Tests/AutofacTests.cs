using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
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
    public class AutofacTests : TestsBase
    {
        IContainer container;

        protected override void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ExtendedCustomer>().As<Customer>();
            builder.RegisterType<CustomerWrapper>().As<CustomerWrapper>();
            container = builder.Build().EnableCustomizations();
        }

        [TestMethod]
        public void Autofac_Resolve()
        {
            customizer.Setup<Customer>()
                .Override<string, string>(c => c.GetFullName(null), (c,f) => "full");

            var customer = container.Resolve<Customer>();
            customer.ShouldNotBeOfType<ExtendedCustomer>();
            customer.ShouldBeAssignableTo<ExtendedCustomer>();
        }

        [TestMethod]
        public void Autofac_InjectedConstructor()
        {
            customizer.Setup<CustomerWrapper>()
                .Override<string>(c => c.GetFullName(), (c) => c.GetFullName());

            for (int i = 0; i < 50000; i++)
            {
                container.Resolve<CustomerWrapper>();
            }
        }

        public class ExtendedCustomer : Customer
        {
            public string MiddleName { get; set; }
        }
    }
}
