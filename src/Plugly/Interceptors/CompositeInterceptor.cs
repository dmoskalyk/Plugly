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
        static Dictionary<CompositeInterceptor, IEnumerator<IInterceptor>> enumerators;

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
            bool start;
            var enumerator = GetEnumerator(out start);
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
                    enumerators.Remove(this);
            }
        }

        IEnumerator<IInterceptor> GetEnumerator(out bool start)
        {
            if (enumerators == null)
                enumerators = new Dictionary<CompositeInterceptor, IEnumerator<IInterceptor>>();

            start = false;
            IEnumerator<IInterceptor> result;
            if (!enumerators.TryGetValue(this, out result))
            {
                result = list.GetEnumerator();
                enumerators.Add(this, result);
                start = true;
            }
            return result;
        }
    }
}