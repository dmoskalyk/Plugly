using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    /// <summary>
    /// A default customizer locator which always returns the same customizer instance.
    /// </summary>
    public sealed class SingleCustomizerLocator : ICustomizerLocator
    {
        Customizer instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleCustomizerLocator"/> class.
        /// </summary>
        /// <param name="instance">The single customizer instance.</param>
        public SingleCustomizerLocator(Customizer instance)
        {
            this.instance = instance;
        }

        /// <summary>
        /// Gets the current customizer instance.
        /// </summary>
        /// <returns>
        /// Returns the single customizer instance.
        /// </returns>
        public Customizer GetCurrent()
        {
            return instance;
        }
    }
}
