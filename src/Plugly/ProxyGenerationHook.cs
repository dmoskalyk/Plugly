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
    sealed class ProxyGenerationHook : IProxyGenerationHook
    {
        [NonSerialized]
        Configuration config;

        public ProxyGenerationHook(Configuration config)
        {
            this.config = config;
        }

        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            return config.HasCustomizations(type, methodInfo);
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            this.config = Customizer.Current.config;
        }
    }
}