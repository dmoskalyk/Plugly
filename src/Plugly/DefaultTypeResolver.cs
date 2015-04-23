using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plugly
{
    sealed class DefaultTypeResolver : ITypeResolver
    {
        public Type ResolveType(Type type)
        {
            return type;
        }
    }
}