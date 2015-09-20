using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    /// <summary>
    /// An interface to a final type resolver.
    /// </summary>
    public interface ITypeResolver
    {
        /// <summary>
        /// Resolves the final (injected) type for the specified original type.
        /// </summary>
        /// <param name="type">The original type.</param>
        /// <returns>Returns the final derived type or the original type.</returns>
        Type ResolveType(Type type);
    }
}
