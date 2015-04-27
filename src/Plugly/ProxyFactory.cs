using Castle.DynamicProxy;
using System;
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
        public Type ProxyType;
        
        Func<object> create;
        Action<object> init;

        public ProxyFactory(ProxyGenerator proxyGenerator, Type type, ProxyGenerationOptions options)
        {
            var classGenerator = new CustomClassProxyGenerator(proxyGenerator.ProxyBuilder.ModuleScope, type) { Logger = proxyGenerator.ProxyBuilder.Logger };
            this.ProxyType = classGenerator.GenerateCode(Type.EmptyTypes, options);
            this.create = MakeCreateExpression(ProxyType, options.Selector, options.MixinData).Compile();
            this.init = MakeInitExpression(ProxyType, options.Selector, options.MixinData).Compile();
        }

        public object Create()
        {
            return create();
        }

        public void InitProxy(object proxy)
        {
            init(proxy);
        }

        Expression<Func<object>> MakeCreateExpression(Type proxyType, IInterceptorSelector selector, MixinData mixins)
        {
            var ctor = proxyType.GetConstructors().First(c => c.GetParameters().Select(p => p.ParameterType).LastOrDefault() == typeof(IInterceptorSelector));
            var arguments = mixins.Mixins.Select(m => Expression.New(m.GetType())).Cast<Expression>().ToList();
            arguments.Add(Expression.Convert(Expression.Constant(null), typeof(IInterceptor[])));
            arguments.Add(Expression.Constant(selector));
            var body = Expression.New(ctor, arguments);
            return Expression.Lambda<Func<object>>(body);
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
