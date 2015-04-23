using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Plugly
{
    sealed class InterceptorSelector : IInterceptorSelector
    {
        Configuration config;

        public InterceptorSelector(Configuration config)
        {
            this.config = config;
        }

        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            return config.GetInterceptors(type, method);
        }
    }
}