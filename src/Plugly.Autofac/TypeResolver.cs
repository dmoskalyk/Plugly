using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Autofac
{
    sealed class TypeResolver : ITypeResolver
    {
        IContainer container;

        public TypeResolver(IContainer container)
        {
            this.container = container;
        }

        public Type ResolveType(Type type)
        {
            foreach (var registration in container.ComponentRegistry.Registrations)
            {
                foreach (var service in registration.Services.OfType<IServiceWithType>())
                {
                    if (service.ServiceType == type)
                        return registration.Activator.LimitType;
                }
            }
            return type;
        }
    }
}
