using Castle.DynamicProxy;
using Plugly.Interceptors;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Plugly
{
    sealed class TypeConfiguration
    {
        ConcurrentDictionary<string, IInterceptor[]> interceptors = new ConcurrentDictionary<string, IInterceptor[]>();
        
        public List<object> Mixins = new List<object>();

        public bool? BuildUp;

        public bool TryGetInterceptors(MethodBase method, out IInterceptor[] result)
        {
            return interceptors.TryGetValue(method.ToString(), out result);
        }

        public T AddInterceptor<T>(MethodBase method, T interceptor)
            where T : IInterceptor
        {
            var i = (CompositeInterceptor)interceptors.GetOrAdd(method.ToString(), k => new IInterceptor[] { new CompositeInterceptor() })[0];
            i.Add(interceptor);
            return interceptor;
        }

        public void Merge(TypeConfiguration config)
        {
            foreach (var entry in config.interceptors)
            {
                interceptors.AddOrUpdate(entry.Key, entry.Value, (k, l) =>
                {
                    var target = (CompositeInterceptor)l[0];
                    var source = (CompositeInterceptor)entry.Value[0];
                    source.CopyTo(target);
                    return l;
                });
            }
            Mixins.AddRange(config.Mixins);
            if (!BuildUp.HasValue)
                BuildUp = config.BuildUp;
        }
    }
}