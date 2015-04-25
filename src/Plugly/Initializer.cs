using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    sealed class Initializer<T> : IInitializer
    {
        Action<T> action;

        public Initializer(Action<T> action)
        {
            this.action = action;
        }

        void IInitializer.Initialize(object instance)
        {
            action((T)instance);
        }
    }

    interface IInitializer
    {
        void Initialize(object instance);
    }
}
