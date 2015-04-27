using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Plugly
{
    public class Customizer
    {
        static ICustomizerLocator locator = new SingleCustomizerLocator(new Customizer());
        static ITypeResolver resolver = new DefaultTypeResolver();

        public static void SetLocator(ICustomizerLocator customizerLocator)
        {
            Customizer.locator = customizerLocator;
        }

        public static void SetResolver(ITypeResolver typeResolver)
        {
            Customizer.resolver = typeResolver;
        }

        public static Customizer Current
        {
            get { return locator.GetCurrent(); }
        }

        Generator generator;
        internal Configuration config;
        Dictionary<string, object> extraData = new Dictionary<string,object>();

        public Dictionary<string, object> ExtraData
        {
            get { return extraData; }
        }

        public Customizer()
        {
            this.config = new Configuration();
            this.generator = new Generator(config);
        }

        public T CreateInstance<T>(bool initialize = true)
        {
            return (T)CreateInstance(typeof(T), initialize);
        }

        public object CreateInstance(Type type, bool initialize = true)
        {
            var instance = generator.CreateInstance(type);
            if (initialize)
                InitializeInstance(type, instance);
            return instance;
        }

        public void InitializeInstance<T>(T instance)
        {
            InitializeInstance(typeof(T), instance);
        }
        
        public void InitializeInstance(Type type, object instance)
        {
            var list = config.GetInitializers(type);
            if (list == null)
                return;
            for (int i = 0; i < list.Count; i++)
                list[i].Initialize(instance);
        }

        public bool IsCustomized(Type type)
        {
            return config.HasCustomizations(type);
        }

        public void RemapType(Type from, Type to)
        {
            generator.Invalidate(from);
            generator.Invalidate(to);
            config.RemapType(from, to);
        }

        public Customizer<T> Setup<T>()
            where T : class
        {
            var targetType = resolver.ResolveType(typeof(T));
            generator.Invalidate(targetType);
            return new Customizer<T>(this, config, targetType);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void InitializeProxy<T>(object proxy)
        {
            Current.generator.InitializeProxy(typeof(T), proxy);
        }
    }
}