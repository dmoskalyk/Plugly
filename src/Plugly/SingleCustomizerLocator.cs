using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public sealed class SingleCustomizerLocator : ICustomizerLocator
    {
        Customizer instance;

        public SingleCustomizerLocator(Customizer instance)
        {
            this.instance = instance;
        }

        public Customizer GetCurrent()
        {
            return instance;
        }
    }
}
