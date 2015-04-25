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
            config.Add<TOwner>(ownerType, GetPropertyMethod(property, true), with); return this;
        }

        public Customizer<TOwner> OverrideSetter<T>(Expression<Func<TOwner, T>> property, Action<TOwner, T> with)
        {
            config.Add<TOwner>(ownerType, GetPropertyMethod(property, false), with); return this;
        }

        public Customizer<TOwner> OverrideProtectedGetter<T>(string property, Func<TOwner, Func<T>, T> with)
        {
            config.Add<TOwner>(ownerType, GetProtectedPropertyMethod(property, true), with, isProtectedWithBaseMethod: true); return this;
        }

        public Customizer<TOwner> OverrideProtectedSetter<T>(string property, Action<TOwner, T, Action<T>> with)
        {
            config.Add<TOwner>(ownerType, GetProtectedPropertyMethod(property, false), with, isProtectedWithBaseMethod: true); return this;
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

        private MethodInfo GetProtectedPropertyMethod(string property, bool getter)
        {
            var propertyInfo = ownerType.GetProperty(property, BindingFlags.Instance | BindingFlags.NonPublic);
            if (propertyInfo == null)
                throw new ArgumentException(string.Format("Protected property '{0}' could not be found.", property));

            var method = getter ? propertyInfo.GetMethod : propertyInfo.SetMethod;
            if (!method.IsVirtual)
                throw new InvalidOperationException("Only virtual properties can be customized.");

            return method;
        }
    }
}
