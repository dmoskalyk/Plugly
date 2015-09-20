using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    /// <summary>
    /// An interface to the current customizer instance locator.
    /// </summary>
    public interface ICustomizerLocator
    {
        /// <summary>
        /// Gets the current customizer instance.
        /// </summary>
        /// <returns>Returns the current customizer instance.</returns>
        Customizer GetCurrent();
    }
}
