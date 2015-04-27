using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Web;

namespace Plugly
{
    [Serializable]
    sealed class InterceptorSelector : IInterceptorSelector
    {
        [NonSerialized]
        Configuration config;

        public InterceptorSelector(Configuration config)
        {
            this.config = config;
        }

        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            return config.GetInterceptors(type, method);
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            this.config = Customizer.Current.config;
        }
    }
}