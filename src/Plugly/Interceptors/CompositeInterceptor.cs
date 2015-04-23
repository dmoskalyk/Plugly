using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plugly.Interceptors
{
    sealed class CompositeInterceptor : IInterceptor
    {
        List<IInterceptor> list;

        [ThreadStatic]
        static IEnumerator<IInterceptor> enumerator;

        public CompositeInterceptor()
        {
            this.list = new List<IInterceptor>();
        }

        public void Add(IInterceptor interceptor)
        {
            list.Insert(0, interceptor);
        }

        public void CopyTo(CompositeInterceptor other)
        {
            other.list.AddRange(this.list);
        }

        public void Intercept(IInvocation invocation)
        {
            bool start = enumerator == null;
            if (start)
                enumerator = list.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                    enumerator.Current.Intercept(invocation);
                else
                    invocation.Proceed();
            }
            finally
            {
                if (start)
                    enumerator = null;
            }
        }
    }
}