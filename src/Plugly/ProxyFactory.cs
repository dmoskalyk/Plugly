using Castle.DynamicProxy;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    sealed class ProxyFactory
    {
        Type originalType;
        Type proxyType;
        ConcurrentDictionary<string, Func<object[], object>> constructors;
        Action<object> init;

        public ProxyFactory(ProxyGenerator proxyGenerator, Type type, ProxyGenerationOptions options)
        {
            this.originalType = type;
            var classGenerator = new CustomClassProxyGenerator(proxyGenerator.ProxyBuilder.ModuleScope, type) { Logger = proxyGenerator.ProxyBuilder.Logger };
            this.proxyType = classGenerator.GenerateCode(Type.EmptyTypes, options);
            this.constructors = new ConcurrentDictionary<string, Func<object[], object>>();
            foreach (var ctor in proxyType.GetConstructors())
            {
                var ctorArgs = ctor.GetParameters();
                if (ctorArgs.Length == 0)
                    continue;
                
                var tuple = MakeCreateExpression(proxyType, options.Selector, options.MixinData, ctor, ctorArgs);
                constructors.TryAdd(tuple.Item1, tuple.Item2.Compile());
            }
            this.init = MakeInitExpression(proxyType, options.Selector, options.MixinData).Compile();
        }

        public object Create(ConstructionParameters parameters)
        {
            if (parameters == null)
                parameters = ConstructionParameters.Empty;

            Func<object[], object> method;
            var values = new object[parameters.ParameterCount];
            var key = new StringBuilder();
            for (int i = 0; i < parameters.ParameterCount; i++)
            {
                key.Append(parameters.ParameterTypes[i].ToString());
                values[i] = parameters.ParameterValues[i]();
            }
            if (!constructors.TryGetValue(key.ToString(), out method))
            {
                if (parameters.ParameterCount > 0)
                    throw new ArgumentException("Constructor for type '" + originalType + "' with argument types '" + string.Join(", ", parameters.ParameterTypes.AsEnumerable()) + "' could not be found.");
                else
                    throw new ArgumentException("Constructor for type '" + originalType + "' with no arguments could not be found.");
            }
            return method(values);
        }

        public void InitProxy(object proxy)
        {
            init(proxy);
        }

        Tuple<string, Expression<Func<object[], object>>> MakeCreateExpression(Type proxyType, IInterceptorSelector selector, MixinData mixins, ConstructorInfo ctor, ParameterInfo[] ctorArgs)
        {
            var key = new StringBuilder();
            var ctorArgsParameter = Expression.Parameter(typeof(object[]));
            var arguments = mixins.Mixins.Select(m => Expression.New(m.GetType())).Cast<Expression>().ToList();
            arguments.Add(Expression.Convert(Expression.Constant(null), typeof(IInterceptor[])));
            arguments.Add(Expression.Constant(selector));
            for (int i = arguments.Count, j = 0; i < ctorArgs.Length; i++, j++)
            {
                key.Append(ctorArgs[i].ParameterType.ToString());
                var argExpr = Expression.ArrayIndex(ctorArgsParameter, Expression.Constant(j));
                arguments.Add(Expression.ConvertChecked(argExpr, ctorArgs[i].ParameterType));
            }
            var body = Expression.New(ctor, arguments);
            var method = Expression.Lambda<Func<object[], object>>(body, ctorArgsParameter);
            return Tuple.Create(key.ToString(), method);
        }

        Expression<Action<object>> MakeInitExpression(Type proxyType, IInterceptorSelector selector, MixinData mixins)
        {
            var fields = proxyType.GetFields().ToDictionary(f => f.Name);
            var parameter = Expression.Parameter(typeof(object));
            var variable = Expression.Variable(proxyType);
            var expressions = new List<Expression>();
            expressions.Add(Expression.Assign(variable, Expression.Convert(parameter, proxyType)));
            expressions.Add(Expression.Assign(
                Expression.MakeMemberAccess(variable, fields["__selector"]), 
                Expression.Constant(selector)
            ));
            expressions.AddRange(mixins.MixinInterfaces.Zip(mixins.Mixins, (t, o) =>
                Expression.Assign(
                    Expression.MakeMemberAccess(variable, fields["__mixin_" + t.FullName.Replace(".", "_")]),
                    Expression.New(o.GetType())
                )
            ));
            return Expression.Lambda<Action<object>>(Expression.Block(new[] { variable }, expressions), parameter);
        }
    }
}
