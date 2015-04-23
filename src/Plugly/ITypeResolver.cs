using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public interface ITypeResolver
    {
        Type ResolveType(Type type);
    }
}
