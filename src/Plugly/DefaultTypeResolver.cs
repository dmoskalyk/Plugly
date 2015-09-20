using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plugly
{
    /// <summary>
    /// A default type resolver which always returns the original type.
    /// </summary>
    public sealed class DefaultTypeResolver : ITypeResolver
    {
        /// <summary>
        /// Resolves the final (injected) type for the specified original type.
        /// </summary>
        /// <param name="type">The original type.</param>
        /// <returns>
        /// Returns the original type.
        /// </returns>
        public Type ResolveType(Type type)
        {
            return type;
        }
    }
}