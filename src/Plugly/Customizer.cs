using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Plugly
{
    public class Customizer
    {
        Generator generator;
        Configuration config;
        ITypeResolver typeResolver;

        public Customizer()
            : this(new DefaultTypeResolver())
        {
        }

        public Customizer(ITypeResolver typeResolver)
        {
            this.typeResolver = typeResolver;
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

        public Customizer SetDefaultBuildUp(bool shouldBuildUp = false)
        {
            config.BuildUpAllTypes = shouldBuildUp;
            return this;
        }

        public bool IsCustomized(Type type)
        {
            return config.HasCustomizations(type);
        }

        public bool ShouldBuildUp(Type type)
        {
            return config.ShouldBuildUp(type);
        }

        public void RemapType(Type from, Type to)
        {
            config.RemapType(from, to);
        }

        public Customizer<T> Setup<T>()
            where T : class
        {
            return new Customizer<T>(this, config, typeResolver.ResolveType(typeof(T)));
        }
    }
}