using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public sealed partial class Customizer<TTarget>
    {
        /// <summary>
        /// Registers an overrides of the public property getter.
        /// </summary>
        /// <typeparam name="T">The type of the property return value.</typeparam>
        /// <param name="property">The property access expression.</param>
        /// <param name="with">The override function which takes the target as the argument and returns the property value.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideGetter<T>(Expression<Func<TTarget, T>> property, Func<TTarget, T> with)
        {
            config.Add<TTarget>(targetType, GetPropertyMethod(property, true), with); return this;
        }

        /// <summary>
        /// Registers an overrides of the public property setter.
        /// </summary>
        /// <typeparam name="T">The type of the property return value.</typeparam>
        /// <param name="property">The property access expression.</param>
        /// <param name="with">The override action which takes the target as the first argument and the new property value as the second one.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideSetter<T>(Expression<Func<TTarget, T>> property, Action<TTarget, T> with)
        {
            config.Add<TTarget>(targetType, GetPropertyMethod(property, false), with); return this;
        }

        /// <summary>
        /// Registers an overrides of the protected property getter.
        /// </summary>
        /// <typeparam name="T">The type of the property return value.</typeparam>
        /// <param name="property">The property name.</param>
        /// <param name="with">The override function which takes the target as the argument, the original property getter function as the second and returns the property value.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtectedGetter<T>(string property, Func<TTarget, Func<T>, T> with)
        {
            config.Add<TTarget>(targetType, GetProtectedPropertyMethod(property, true), with, isProtectedWithBaseMethod: true); return this;
        }

        /// <summary>
        /// Registers an overrides of the protected property setter.
        /// </summary>
        /// <typeparam name="T">The type of the property return value.</typeparam>
        /// <param name="property">The property name.</param>
        /// <param name="with">The override action which takes the target as the argument, the new property value as the second one and the original property setter function as the last argument.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtectedSetter<T>(string property, Action<TTarget, T, Action<T>> with)
        {
            config.Add<TTarget>(targetType, GetProtectedPropertyMethod(property, false), with, isProtectedWithBaseMethod: true); return this;
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
            var propertyInfo = targetType.GetProperty(property, BindingFlags.Instance | BindingFlags.NonPublic);
            if (propertyInfo == null)
                throw new ArgumentException(string.Format("Protected property '{0}' could not be found.", property));

            var method = getter ? propertyInfo.GetMethod : propertyInfo.SetMethod;
            if (!method.IsVirtual)
                throw new InvalidOperationException("Only virtual properties can be customized.");

            return method;
        }
    }
}
