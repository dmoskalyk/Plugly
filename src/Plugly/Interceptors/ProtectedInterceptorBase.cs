using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Interceptors
{
    abstract class ProtectedInterceptorBase<TOwner, TAction, TBaseMethod> : InterceptorBase<TAction>
    {
        protected TBaseMethod baseMethod;

        public override void Initialize(MethodInfo method, TAction action)
        {
            base.Initialize(method, action);
            this.baseMethod = CreateBaseMethodDelegate(method);
        }

        static TBaseMethod CreateBaseMethodDelegate(MethodInfo methodInfo)
        {
            var args = methodInfo.GetParameters().Select(p => p.ParameterType).ToList();
            args.Insert(0, typeof(TOwner));
            var parameters = args.Select(a => Expression.Parameter(a)).ToArray();
            return Expression.Lambda<TBaseMethod>(Expression.Call(parameters[0], methodInfo), parameters).Compile();
        }
    }
}
