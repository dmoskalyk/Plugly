using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public sealed partial class Customizer<TOwner>
    {
        public Customizer<TOwner> Override(string method, Delegate with)
        {
            return Override(method, null, with);
        }

        public Customizer<TOwner> Override(string method, Type[] types, Delegate with)
        {
            var methodInfo = ownerType.GetMethod(method, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            if (methodInfo == null)
                throw new ArgumentException("Method '" + method + "' not found.", "method");
            config.AddUntyped<TOwner>(ownerType, methodInfo, with);
            return this;
        }
    }
}
