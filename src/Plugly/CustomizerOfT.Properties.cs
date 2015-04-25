using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public sealed partial class Customizer<TOwner>
    {
        public Customizer<TOwner> OverrideGetter<T>(Expression<Func<TOwner, T>> property, Func<TOwner, T> with)
        {
            config.Add(ownerType, GetPropertyMethod(property, true), with); return this;
        }

        public Customizer<TOwner> OverrideSetter<T>(Expression<Func<TOwner, T>> property, Action<TOwner, T> with)
        {
            config.Add(ownerType, GetPropertyMethod(property, false), with); return this;
        }

        private MethodInfo GetPropertyMethod(LambdaExpression property, bool getter)
        {
            var propertyAccessor = property.Body as MemberExpression;
            if (propertyAccessor == null || !(propertyAccessor.Member is PropertyInfo))
                throw new ArgumentException("The provided expression must be a property access expression.", "property");

            var propertyInfo = (PropertyInfo)propertyAccessor.Member;
            var method = getter ? propertyInfo.GetMethod : propertyInfo.SetMethod;
            if (!method.IsVirtual)
                throw new InvalidOperationException("Only virtual properties can be customized.");

            return method;
        }
    }
}
