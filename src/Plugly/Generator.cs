using Castle.DynamicProxy;
using Plugly.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plugly
{
    sealed class Generator
    {
        ProxyGenerator proxyGenerator;
        ProxyGenerationHook hook;
        ProxyGenerationOptions defaultOptions;
        InterceptorSelector selector;
        Configuration config;

        public Generator(Configuration config)
        {
            this.config = config;
            this.proxyGenerator = new ProxyGenerator();
            this.selector = new InterceptorSelector(config);
            this.hook = new ProxyGenerationHook(config);
            this.defaultOptions = new ProxyGenerationOptions(hook) { Selector = selector };
        }

        public object CreateInstance(Type type)
        {
            return proxyGenerator.CreateClassProxy(type, GetOptions(type));
        }

        ProxyGenerationOptions GetOptions(Type type)
        {
            var mixins = config.GetMixins(type);
            if (mixins == null || mixins.Count == 0)
                return defaultOptions;

            var options = new ProxyGenerationOptions(hook) { Selector = selector };
            for (int i = 0; i < mixins.Count; i++)
            {
                options.AddMixinInstance(mixins[i]);
            }
            return options;
        }
    }
}