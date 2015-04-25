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
    sealed class Configuration
    {
        static IInterceptor[] NoInterceptors = new IInterceptor[0];
        
        static MethodInfo addMethodInfo = typeof(Configuration).GetMethod("AddInner", BindingFlags.NonPublic | BindingFlags.Instance);
        static MethodInfo addInitializerMethodInfo = typeof(Configuration).GetMethod("AddInitializerInner", BindingFlags.NonPublic | BindingFlags.Instance);
        
        ConcurrentDictionary<Type, TypeConfiguration> registrations = new ConcurrentDictionary<Type, TypeConfiguration>();

        public bool BuildUpAllTypes = false;

        public void RemapType(Type from, Type to)
        {
            if (from == to)
                return;

            if (MergeConfig(from, to))
                return;
            
            foreach (var type in registrations.Keys)
            {
                if (from.IsAssignableFrom(type))
                    MergeConfig(type, to);
            }
        }

        bool MergeConfig(Type from, Type to)
        {
            TypeConfiguration fromConfig;
            if (!registrations.TryRemove(from, out fromConfig))
                return false;

            registrations.AddOrUpdate(to, fromConfig, (t, c) => { c.Merge(fromConfig); return c; });
            return true;
        }

        public bool HasCustomizations(Type type)
        {
            TypeConfiguration config;
            return registrations.TryGetValue(type, out config) && config.HasCustomizations();
        }

        public bool HasCustomizations(Type type, MethodInfo method)
        {
            return GetInterceptors(type, method).Length > 0;
        }

        public bool ShouldBuildUp(Type type)
        {
            TypeConfiguration config;
            if (registrations.TryGetValue(type, out config) && config.BuildUp.HasValue)
                return config.BuildUp.Value;
            else
                return BuildUpAllTypes;
        }

        public void SetBuildUp(Type type, bool buildUp)
        {
            registrations
                .GetOrAdd(type, t => new TypeConfiguration())
                .BuildUp = buildUp;
        }

        public IInterceptor[] GetInterceptors(Type type, MethodInfo method)
        {
            TypeConfiguration config;
            IInterceptor[] result;
            if (registrations.TryGetValue(method.DeclaringType, out config) && config.TryGetInterceptors(method, out result))
                return result;
            else
                return NoInterceptors;
        }

        public void AddInitializer(Type type, Delegate initializer)
        {
            var t = initializer.GetType().GetGenericArguments()[0];
            addInitializerMethodInfo.MakeGenericMethod(t).Invoke(this, new object[] { type, initializer });
        }
        
        public void AddInitializer<T>(Type type, Action<T> initializer)
        {
            AddInitializerInner<T>(type, initializer);
        }

        private void AddInitializerInner<T>(Type type, Action<T> initializer)
        {
            registrations
                .GetOrAdd(type, t => new TypeConfiguration())
                .Initializers.Add(new Initializer<T>(initializer));
        }

        public IList<IInitializer> GetInitializers(Type type)
        {
            TypeConfiguration config;
            if (registrations.TryGetValue(type, out config))
                return config.Initializers;
            else
                return null;
        }

        public void AddMixin(Type type, Type mixin)
        {
            CheckNotSealed(type);
            registrations
                .GetOrAdd(type, t => new TypeConfiguration())
                .Mixins.Add(LinqHelper.MakeObjectFactory(mixin));
        }

        public IList<Func<object>> GetMixins(Type type)
        {
            TypeConfiguration config;
            if (registrations.TryGetValue(type, out config))
                return config.Mixins;
            else
                return null;
        }

        private void AddInner<TFunc, TInt>(Type type, MethodInfo method, TFunc action)
            where TInt : InterceptorBase<TFunc>, new()
        {
            CheckNotSealed(type);
            registrations
                .GetOrAdd(type, t => new TypeConfiguration())
                .AddInterceptor(method, new TInt())
                .Initialize(method, action);
        }

        public void Add<TTarget>(Type type, MethodInfo method, Delegate action, bool isProtectedWithBaseMethod = false)
        {
            var parametersTypes = method.GetParameters().Select(p => p.ParameterType).ToList();
            parametersTypes.Insert(0, typeof(TTarget));
            Type interceptorType;
            if (method.ReturnType == typeof(void))
            {
                interceptorType = isProtectedWithBaseMethod ? 
                    TypeHelper.GetProtectedActionInterceptorType(parametersTypes.ToArray()) : 
                    TypeHelper.GetActionInterceptorType(parametersTypes.ToArray());
            }
            else
            {
                parametersTypes.Add(method.ReturnType);
                interceptorType = isProtectedWithBaseMethod ?
                    TypeHelper.GetProtectedFuncInterceptorType(parametersTypes.ToArray()) :
                    TypeHelper.GetFuncInterceptorType(parametersTypes.ToArray());
            }
            var actionType = interceptorType.BaseType.GetGenericArguments()[isProtectedWithBaseMethod ? 1 : 0];
            addMethodInfo.MakeGenericMethod(actionType, interceptorType).Invoke(this, new object[] { type, method, action });
        }

        private void CheckNotSealed(Type type)
        {
            if (type.IsSealed)
                throw new InvalidOperationException("Cannot customize sealed class.");
        }
    }
}