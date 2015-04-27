using Castle.DynamicProxy;
using Plugly.Interceptors;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

        ConcurrentDictionary<Type, ProxyFactory> factories = new ConcurrentDictionary<Type, ProxyFactory>();

        public Generator(Configuration config)
        {
            this.config = config;
            this.proxyGenerator = new ProxyGenerator();
            this.selector = new InterceptorSelector(config);
            this.hook = new ProxyGenerationHook(config);
            this.defaultOptions = new ProxyGenerationOptions(hook) { Selector = selector };
        }

        public void Invalidate(Type type)
        {
            ProxyFactory ignored;
            factories.TryRemove(type, out ignored);
        }

        public object CreateInstance(Type type)
        {
            return factories.GetOrAdd(type, CreateFactory).Create();
        }

        public void InitializeProxy(Type type, object proxy)
        {
            factories.GetOrAdd(type, CreateFactory).InitProxy(proxy);
        }

        ProxyFactory CreateFactory(Type type)
        {
            ProxyGenerationOptions options;
            var mixins = config.GetMixins(type);
            if (mixins == null || mixins.Count == 0)
            {
                options = defaultOptions;
            }
            else
            {
                options = new ProxyGenerationOptions(hook) { Selector = selector };
                for (int i = 0; i < mixins.Count; i++)
                    options.AddMixinInstance(mixins[i]());
            }
            return new ProxyFactory(proxyGenerator, type, options);
        }
    }
}