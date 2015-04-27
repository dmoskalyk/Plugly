using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Autofac
{
    public static class Extension
    {
        public static IContainer Setup(IContainer container)
        {
            Customizer.SetResolver(new TypeResolver(container));
            foreach (var item in container.ComponentRegistry.Registrations.OfType<ComponentRegistration>())
            {
                if (!(item.Activator is InstanceActivator) && item.Activator.LimitType.IsClass && !item.Activator.LimitType.IsAbstract)
                    item.Activator = new InstanceActivator(item.Activator);
            }
            return container;
        }
    }
}
