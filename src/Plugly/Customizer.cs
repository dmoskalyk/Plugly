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

        internal Configuration Config
        {
            get { return config; }
        }

        public Customizer() : this(new DefaultTypeResolver())
        {
        }

        public Customizer(ITypeResolver typeResolver)
        {
            this.typeResolver = typeResolver;
            this.config = new Configuration();
            this.generator = new Generator(config);
        }

        public T CreateInstance<T>()
        {
            return (T)CreateInstance(typeof(T));
        }

        public object CreateInstance(Type type)
        {
            return generator.CreateInstance(type);
        }

        public Customizer BuildUpTypes(bool shouldBuildUp = false)
        {
            config.BuildUpAllTypes = shouldBuildUp;
            return this;
        }

        public bool IsCustomized(Type type)
        {
            return config.HasRegistrationsFor(type);
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
            return new Customizer<T>(this, typeResolver.ResolveType(typeof(T)));
        }
    }
}