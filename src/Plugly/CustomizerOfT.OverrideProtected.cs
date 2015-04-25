using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public sealed partial class Customizer<TOwner>
    {
        public Customizer<TOwner> OverrideProtected<TDerivedClass, TResult>(
            Expression<Func<TDerivedClass, TResult>> method,
            Expression<Func<TDerivedClass, TResult>> with)
        {
            var d = LinqHelper.RemapCalls(typeof(TDerivedClass), ownerType, with);
            config.AddUntyped<TOwner>(ownerType, GetMethod(method), d); 
            return this;
        }
    }
}
