using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plugly.Unity
{
    sealed class TypeResolver : ITypeResolver
    {
        IUnityContainer container;

        public TypeResolver(IUnityContainer container)
        {
            this.container = container;
        }

        public Type ResolveType(Type type)
        {
            if (container.IsRegistered(type))
                return (from r in container.Registrations where r.RegisteredType == type orderby r.Name select r.MappedToType).FirstOrDefault() ?? type;
            else
                return type;
        }
    }
}