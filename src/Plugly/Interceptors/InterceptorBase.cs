using Castle.DynamicProxy;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Plugly.Interceptors
{
    abstract class InterceptorBase<TAction> : IInterceptor
    {
        TAction action;

        public void SetAction(TAction action)
        {
            this.action = action;
        }

        public void Intercept(IInvocation invocation)
        {
            Invoke(action, invocation);
        }

        protected abstract void Invoke(TAction action, IInvocation invocation);
    }
}