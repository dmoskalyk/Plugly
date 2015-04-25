using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var methodInfo = ownerType.GetMethod(method, BindingFlags.Instance | BindingFlags.Public);
            if (methodInfo == null)
                throw new ArgumentException("Method '" + method + "' not found.", "method");
            config.AddUntyped<TOwner>(ownerType, methodInfo, with);
            return this;
        }

        public Customizer<TOwner> ExtendWith<T>()
            where T : class
        {
            return ExtendWith(typeof(T));
        }

        public Customizer<TOwner> ExtendWith(Type extension)
        {
            if (!extension.IsAbstract && extension.GetConstructor(Type.EmptyTypes) != null)
            {
                if (extension.GetInterfaces().Any(i => i.GetProperties().Length > 0))
                {
                    config.AddMixin(ownerType, Activator.CreateInstance(extension));
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
                if (!method.IsStatic || args.Length == 0 || !typeof(TOwner).IsAssignableFrom(args[0].ParameterType))
                    throw new ArgumentException(string.Format("The customization method '{0}' must be static and have the first parameter of type derived from '{1}'.", method.Name, typeof(TOwner).FullName));

                if (method.Name == "__init")
                {
                    if (args.Length > 1)
                        throw new ArgumentException("The '__init' method can have only one argument.");
                    var delegateType = typeof(Action<>).MakeGenericType(args[0].ParameterType);
                    config.AddInitializer(ownerType, Delegate.CreateDelegate(delegateType, method));
                }
                else
                {
                    var targetMethodArgs = args.Skip(1).Select(a => a.ParameterType).ToArray();
                    var targetMethod = ownerType.GetMethod(method.Name, BindingFlags.Instance | BindingFlags.Public, null, targetMethodArgs, null);
                    if (targetMethod == null)
                        throw new MissingMethodException(string.Format("Cannot find method to customize: {0}({1})", method.Name, string.Join(",", targetMethodArgs.Select(a => a.FullName))));
                
                    if (method.ReturnType != targetMethod.ReturnType)
                        throw new ArgumentException(string.Format("The return type '{1}' of the customization method '{0}' does not match the target method return type '{2}'.", method.Name, method.ReturnType, targetMethod.ReturnType));
                
                    var delegateType = (method.ReturnType == typeof(void)) ? 
                        TypeHelper.GetActionDelegateType(args.Length).MakeGenericType(args.Select(a => a.ParameterType).ToArray()) :
                        TypeHelper.GetFuncDelegateType(args.Length + 1).MakeGenericType(args.Select(a => a.ParameterType).Concat(new[] { method.ReturnType }).ToArray());
                    config.AddUntyped<TOwner>(ownerType, targetMethod, Delegate.CreateDelegate(delegateType, method));
                }
                customized = true;
            }
            return customized;
        }
    }
}
