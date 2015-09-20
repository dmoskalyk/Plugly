using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public sealed partial class Customizer<TTarget>
    {
        /// <summary>
        /// Overrides the public method with the specified name. In case of multiple method overloads, use <see cref="OverrideUntyped(string, Type[], Delegate)"/> method instead.
        /// </summary>
        /// <param name="method">The method name.</param>
        /// <param name="with">The delegate to override with.</param>
        /// <returns>Returns self customizer instance.</returns>
        public Customizer<TTarget> OverrideUntyped(string method, Delegate with)
        {
            return OverrideUntyped(method, null, with);
        }

        /// <summary>
        /// Overrides the public method with the specified name and argument types.
        /// </summary>
        /// <param name="method">The method name.</param>
        /// <param name="types">The method arguments types.</param>
        /// <param name="with">The delegate to override with.</param>
        /// <returns>Returns self customizer instance.</returns>
        /// <exception cref="System.ArgumentException">Method not found.</exception>
        public Customizer<TTarget> OverrideUntyped(string method, Type[] types, Delegate with)
        {
            var methodInfo = types != null ?
                targetType.GetMethod(method, BindingFlags.Instance | BindingFlags.Public, null, types, null) :
                targetType.GetMethod(method, BindingFlags.Instance | BindingFlags.Public);
            if (methodInfo == null)
                throw new ArgumentException("Method '" + method + "' not found.", "method");
            config.Add<TTarget>(targetType, methodInfo, with);
            return this;
        }

        /// <summary>
        /// Extends the target type with the specified extension.
        /// Extension type may be a mixin, contain customization methods or both.
        /// </summary>
        /// <typeparam name="TExtension">The type of the extension.</typeparam>
        /// <returns>Returns self customizer instance.</returns>
        /// <exception cref="System.ArgumentException">
        /// The provided type must contain at least one method marked with 'CustomizationAttribute' or implement at least one interface with at least one property.
        /// </exception>
        public Customizer<TTarget> ExtendWith<TExtension>()
            where TExtension : class
        {
            return ExtendWith(typeof(TExtension));
        }

        /// <summary>
        /// Extends the target type with the specified extension.
        /// Extension type may be a mixin, contain customization methods or both.
        /// </summary>
        /// <param name="extension">The type of the extension.</param>
        /// <returns>Returns self customizer instance.</returns>
        /// <exception cref="System.ArgumentException">
        /// The provided type must contain at least one method marked with 'CustomizationAttribute' or implement at least one interface with at least one property.
        /// </exception>
        public Customizer<TTarget> ExtendWith(Type extension)
        {
            if (!extension.IsAbstract && extension.GetConstructor(Type.EmptyTypes) != null)
            {
                if (extension.GetInterfaces().Any(i => i.GetProperties().Length > 0))
                {
                    config.AddMixin(targetType, extension);
                    CustomizeWith(extension);
                }
                else
                {
                    if (!CustomizeWith(extension))
                        throw new ArgumentException("The provided type must contain at least one method marked with 'CustomizationAttribute' or implement at least one interface with at least one property.");
                }
            }
            else
            {
                if (!CustomizeWith(extension))
                    throw new ArgumentException("There are no customization methods marked with the 'CustomizationAttribute' in the provided type.");
            }
            return this;
        }

        bool CustomizeWith(Type customizationsContainer)
        {
            bool customized = false;
            var methods = customizationsContainer.GetMethods(
                BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var method in methods)
            {
                if (method.GetCustomAttribute<CustomizationAttribute>() == null)
                    continue;

                var args = method.GetParameters();
                if (!method.IsStatic || args.Length == 0 || !typeof(TTarget).IsAssignableFrom(args[0].ParameterType))
                    throw new ArgumentException(string.Format("The customization method '{0}' must be static and have the first parameter of type derived from '{1}'.", method.Name, typeof(TTarget).FullName));

                if (method.Name == "__init")
                {
                    if (args.Length > 1)
                        throw new ArgumentException("The '__init' method can have only one argument.");
                    var delegateType = typeof(Action<>).MakeGenericType(args[0].ParameterType);
                    config.AddInitializer(targetType, Delegate.CreateDelegate(delegateType, method));
                }
                else
                {
                    var targetMethodArgs = args.Skip(1).Select(a => a.ParameterType).ToArray();
                    var targetMethod = targetType.GetMethod(method.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, targetMethodArgs, null);
                    if (targetMethod == null)
                        targetMethod = targetType.GetMethod(method.Name, BindingFlags.Instance | BindingFlags.NonPublic, null, targetMethodArgs.Take(targetMethodArgs.Length - 1).ToArray(), null);
                    
                    if (targetMethod == null)
                        throw new MissingMethodException(string.Format("Cannot find method to customize: {0}({1})", method.Name, string.Join(",", targetMethodArgs.Select(a => a.FullName))));

                    if (!targetMethod.IsVirtual)
                        throw new InvalidOperationException(string.Format("The method '{0}' cannot be customized because it is not virtual.", method.Name));

                    var isProtectedWithBaseMethod = !targetMethod.IsPublic && args.Length - 1 > targetMethod.GetParameters().Length;
                    if (isProtectedWithBaseMethod && !TypeHelper.Matches(targetMethod, targetMethodArgs[targetMethodArgs.Length - 1]))
                        throw new ArgumentException("The last argument of the protected method customization must be a 'Func<>' or 'Action<>' delegate matching the original method signature.");

                    if (method.ReturnType != targetMethod.ReturnType)
                        throw new ArgumentException(string.Format("The return type '{1}' of the customization method '{0}' does not match the target method return type '{2}'.", method.Name, method.ReturnType, targetMethod.ReturnType));
                
                    var delegateType = (method.ReturnType == typeof(void)) ?
                        TypeHelper.GetActionDelegateType(args.Select(a => a.ParameterType).ToArray()) :
                        TypeHelper.GetFuncDelegateType(args.Select(a => a.ParameterType).Concat(new[] { method.ReturnType }).ToArray());
                    config.Add<TTarget>(targetType, targetMethod, Delegate.CreateDelegate(delegateType, method), isProtectedWithBaseMethod);
                }
                customized = true;
            }
            return customized;
        }
    }
}
