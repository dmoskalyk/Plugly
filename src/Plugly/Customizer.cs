using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Plugly
{
    /// <summary>
    /// The entry point to the customization API.
    /// </summary>
    public sealed class Customizer
    {
        static ICustomizerLocator locator = new SingleCustomizerLocator(new Customizer());
        static ITypeResolver resolver = new DefaultTypeResolver();

        /// <summary>
        /// Sets the customizer instance locator.
        /// </summary>
        /// <param name="customizerLocator">The current customizer instance locator.</param>
        public static void SetLocator(ICustomizerLocator customizerLocator)
        {
            Customizer.locator = customizerLocator;
        }

        /// <summary>
        /// Sets the final type resolver.
        /// </summary>
        /// <param name="typeResolver">The type resolver.</param>
        public static void SetResolver(ITypeResolver typeResolver)
        {
            Customizer.resolver = typeResolver;
        }

        /// <summary>
        /// Gets the current customizer instance.
        /// </summary>
        /// <value>
        /// The current customizer instance.
        /// </value>
        public static Customizer Current
        {
            get { return locator.GetCurrent(); }
        }

        Generator generator;
        internal Configuration config;
        Dictionary<string, object> extraData = new Dictionary<string,object>();

        /// <summary>
        /// Gets the extra data dictionary which can be used to store additional data with the customizer instance.
        /// </summary>
        /// <value>
        /// The extra data dictionary.
        /// </value>
        public Dictionary<string, object> ExtraData
        {
            get { return extraData; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customizer"/> class.
        /// </summary>
        public Customizer()
        {
            this.config = new Configuration();
            this.generator = new Generator(config);
        }

        /// <summary>
        /// Creates a customized proxy instance of the requested type.
        /// </summary>
        /// <typeparam name="T">The type to create proxy for.</typeparam>
        /// <param name="parameters">The construction parameters.</param>
        /// <param name="initialize">If set to <c>true</c>, the instance should be initialized using the registered initializers.</param>
        /// <returns>Returns a new proxy instance.</returns>
        public T CreateInstance<T>(ConstructionParameters parameters = null, bool initialize = true)
        {
            return (T)CreateInstance(typeof(T), parameters, initialize);
        }

        /// <summary>
        /// Creates a customized proxy instance of the requested type.
        /// </summary>
        /// <param name="type">The type to create proxy for.</param>
        /// <param name="parameters">The construction parameters.</param>
        /// <param name="initialize">If set to <c>true</c>, the instance should be initialized using the registered initializers.</param>
        /// <returns>Returns a new proxy instance.</returns>
        public object CreateInstance(Type type, ConstructionParameters parameters = null, bool initialize = true)
        {
            var instance = generator.CreateInstance(type, parameters);
            if (initialize)
                InitializeInstance(type, instance);
            return instance;
        }

        /// <summary>
        /// Initializes the instance using the registered initializers.
        /// </summary>
        /// <typeparam name="T">The type of the instance.</typeparam>
        /// <param name="instance">The instance.</param>
        public void InitializeInstance<T>(T instance)
        {
            InitializeInstance(typeof(T), instance);
        }

        /// <summary>
        /// Initializes the instance using the registered initializers.
        /// </summary>
        /// <param name="type">The type of the instance.</param>
        /// <param name="instance">The instance.</param>
        public void InitializeInstance(Type type, object instance)
        {
            var list = config.GetInitializers(type);
            if (list == null)
                return;
            for (int i = 0; i < list.Count; i++)
                list[i].Initialize(instance);
        }

        /// <summary>
        /// Determines whether the specified type has any registered customizations.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>Returns the value indicating whether there are any registered customizations for the specified type.</returns>
        public bool IsCustomized(Type type)
        {
            return config.HasCustomizations(type);
        }

        /// <summary>
        /// Remaps all customizations for the <paramref name="baseType"/> to the <paramref name="derivedType"/>.
        /// </summary>
        /// <param name="baseType">The base type.</param>
        /// <param name="derivedType">The derived type.</param>
        /// <exception cref="System.ArgumentException">The base type should be assignable from a derived type.</exception>
        public void RemapType(Type baseType, Type derivedType)
        {
            if (!baseType.IsAssignableFrom(derivedType))
                throw new ArgumentException("The base type should be assignable from a derived type.");
            generator.Invalidate(baseType);
            generator.Invalidate(derivedType);
            config.RemapType(baseType, derivedType);
        }

        /// <summary>
        /// Gets the customization API for the specified type.
        /// </summary>
        /// <typeparam name="T">The type to setup.</typeparam>
        /// <returns>Returns an API which can be used to setup customizations for the specified type.</returns>
        public Customizer<T> Setup<T>()
            where T : class
        {
            var targetType = resolver.ResolveType(typeof(T));
            generator.Invalidate(targetType);
            return new Customizer<T>(this, config, targetType);
        }

        /// <summary>
        /// This method is for internal purposes only and is not intended to be used explicitly.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="proxy">The proxy instance.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void InitializeProxy<T>(object proxy)
        {
            Current.generator.InitializeProxy(typeof(T), proxy);
        }
    }
}