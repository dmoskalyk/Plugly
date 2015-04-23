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

    public sealed class Customizer<TOwner>
    {
        Customizer parent;
        Type ownerType;
        Configuration config;

        internal Customizer(Customizer parent, Type ownerType)
        {
            this.parent = parent;
            this.config = parent.Config;
            this.ownerType = ownerType;
        }

        public Customizer<T> Setup<T>()
            where T : class
        {
            return parent.Setup<T>();
        }

        public Customizer<TOwner> BuildUp(bool shouldBuildUp)
        {
            config.SetBuildUp(ownerType, shouldBuildUp);
            return this;
        }

        public Customizer<TOwner> ExtendWith<T>()
            where T : class, new()
        {
            return ExtendWith(new T());
        }

        public Customizer<TOwner> ExtendWith(object mixin)
        {
            config.AddMixin(ownerType, mixin);
            return this;
        }

        private System.Reflection.MethodInfo GetMethod(LambdaExpression method)
        {
            var methodCall = method.Body as MethodCallExpression;
            if (methodCall == null)
                throw new ArgumentException("The provided expression must be a method call expression.", "method");

            return methodCall.Method;
        }

        #region Func registrations
        
        public Customizer<TOwner> Override<TResult>(
            Expression<Func<TOwner, TResult>> method, 
            Func<TOwner, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, TResult>(
            Expression<Func<TOwner, T1, TResult>> method, 
            Func<TOwner, T1, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, TResult>(
            Expression<Func<TOwner, T1, T2, TResult>> method,
            Func<TOwner, T1, T2, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, TResult>(
            Expression<Func<TOwner, T1, T2, T3, TResult>> method,
            Func<TOwner, T1, T2, T3, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, TResult>(
            Expression<Func<TOwner, T1, T2, T3, T4, TResult>> method,
            Func<TOwner, T1, T2, T3, T4, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, TResult>(
            Expression<Func<TOwner, T1, T2, T3, T4, T5, TResult>> method,
            Func<TOwner, T1, T2, T3, T4, T5, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, TResult>(
            Expression<Func<TOwner, T1, T2, T3, T4, T5, T6, TResult>> method,
            Func<TOwner, T1, T2, T3, T4, T5, T6, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, TResult>(
            Expression<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, TResult>> method,
            Func<TOwner, T1, T2, T3, T4, T5, T6, T7, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            Expression<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, TResult>> method,
            Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            Expression<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> method,
            Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            Expression<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> method,
            Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            Expression<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> method,
            Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            Expression<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>> method,
            Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            Expression<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>> method,
            Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            Expression<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>> method,
            Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            Expression<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>> method,
            Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        #endregion

        #region Action registrations

        public Customizer<TOwner> Override(Expression<Action<TOwner>> method, Action<TOwner> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1>(Expression<Action<TOwner, T1>> method, Action<TOwner, T1> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2>(
            Expression<Action<TOwner, T1, T2>> method,
            Action<TOwner, T1, T2> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3>(
            Expression<Action<TOwner, T1, T2, T3>> method,
            Action<TOwner, T1, T2, T3> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4>(
            Expression<Action<TOwner, T1, T2, T3, T4>> method,
            Action<TOwner, T1, T2, T3, T4> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5>(
            Expression<Action<TOwner, T1, T2, T3, T4, T5>> method,
            Action<TOwner, T1, T2, T3, T4, T5> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6>(
            Expression<Action<TOwner, T1, T2, T3, T4, T5, T6>> method,
            Action<TOwner, T1, T2, T3, T4, T5, T6> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7>(
            Expression<Action<TOwner, T1, T2, T3, T4, T5, T6, T7>> method,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8>(
            Expression<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8>> method,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Expression<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9>> method,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Expression<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> method,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Expression<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> method,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Expression<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> method,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Expression<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> method,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Expression<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> method,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        public Customizer<TOwner> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Expression<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> method,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> overridden)
        {
            config.Add(ownerType, GetMethod(method), overridden); return this;
        }

        #endregion
    }
}