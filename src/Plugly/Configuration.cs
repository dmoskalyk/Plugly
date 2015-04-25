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

        public bool HasRegistrationsFor(Type type)
        {
            TypeConfiguration config;
            return registrations.TryGetValue(type, out config);
        }

        public bool HasRegistrationsFor(Type type, MethodInfo method)
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

        public IInterceptor[] GetInterceptors(Type type, MethodBase method)
        {
            TypeConfiguration config;
            IInterceptor[] result;
            if (registrations.TryGetValue(method.DeclaringType, out config) && config.TryGetInterceptors(method, out result))
                return result;
            else
                return NoInterceptors;
        }

        public void AddMixin(Type type, object mixin)
        {
            registrations
                .GetOrAdd(type, t => new TypeConfiguration())
                .Mixins.Add(mixin);
        }

        public IList<object> GetMixins(Type type)
        {
            TypeConfiguration config;
            if (registrations.TryGetValue(type, out config))
                return config.Mixins;
            else
                return null;
        }

        private void AddInner<TFunc, TInt>(Type type, MethodBase method, TFunc action)
            where TInt : InterceptorBase<TFunc>, new()
        {
            registrations
                .GetOrAdd(type, t => new TypeConfiguration())
                .AddInterceptor(method, new TInt())
                .SetAction(action);
        }

        public void AddUntyped<TOwner>(Type type, MethodInfo method, Delegate action)
        {
            var parametersTypes = method.GetParameters().Select(p => p.ParameterType).ToList();
            parametersTypes.Insert(0, typeof(TOwner));
            if (method.ReturnType == typeof(void))
            {
                var paramTypesArray = parametersTypes.ToArray();
                var actionType = TypeHelper.GetActionDelegateType(paramTypesArray.Length).MakeGenericType(paramTypesArray);
                var interceptorType = TypeHelper.GetActionInterceptorType(paramTypesArray.Length).MakeGenericType(paramTypesArray);
                addMethodInfo.MakeGenericMethod(actionType, interceptorType).Invoke(this, new object[] { type, method, action });
            }
            else
            {
                parametersTypes.Add(method.ReturnType);
                var paramTypesArray = parametersTypes.ToArray();
                var actionType = TypeHelper.GetFuncDelegateType(paramTypesArray.Length).MakeGenericType(paramTypesArray);
                var interceptorType = TypeHelper.GetFuncInterceptorType(paramTypesArray.Length).MakeGenericType(paramTypesArray);
                addMethodInfo.MakeGenericMethod(actionType, interceptorType).Invoke(this, new object[] { type, method, action });
            }
        }

        #region Func registrations
        
        public void Add<TOwner, TResult>(Type type, MethodBase method, Func<TOwner, TResult> action)
        {
            AddInner<Func<TOwner, TResult>, FuncInterceptor<TOwner, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, TResult>(Type type, MethodBase method, Func<TOwner, T1, TResult> action)
        {
            AddInner<Func<TOwner, T1, TResult>, FuncInterceptor<TOwner, T1, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, TResult>, FuncInterceptor<TOwner, T1, T2, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, TResult>, FuncInterceptor<TOwner, T1, T2, T3, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, T4, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, T4, TResult>, FuncInterceptor<TOwner, T1, T2, T3, T4, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, T4, T5, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, T4, T5, TResult>, FuncInterceptor<TOwner, T1, T2, T3, T4, T5, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, T4, T5, T6, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, T4, T5, T6, TResult>, FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, T4, T5, T6, T7, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, TResult>, FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, TResult>, FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>, FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>, FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>, FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>, FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>, FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Type type, MethodBase method, Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> action)
        {
            AddInner<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>, FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>>(type, method, action);
        }

        #endregion

        #region Action registrations

        public void Add<TOwner>(Type type, MethodBase method, Action<TOwner> action)
        {
            AddInner<Action<TOwner>, ActionInterceptor<TOwner>>(type, method, action);
        }

        public void Add<TOwner, T1>(Type type, MethodBase method, Action<TOwner, T1> action)
        {
            AddInner<Action<TOwner, T1>, ActionInterceptor<TOwner, T1>>(type, method, action);
        }

        public void Add<TOwner, T1, T2>(Type type, MethodBase method, Action<TOwner, T1, T2> action)
        {
            AddInner<Action<TOwner, T1, T2>, ActionInterceptor<TOwner, T1, T2>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3>(Type type, MethodBase method, Action<TOwner, T1, T2, T3> action)
        {
            AddInner<Action<TOwner, T1, T2, T3>, ActionInterceptor<TOwner, T1, T2, T3>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4>(Type type, MethodBase method, Action<TOwner, T1, T2, T3, T4> action)
        {
            AddInner<Action<TOwner, T1, T2, T3, T4>, ActionInterceptor<TOwner, T1, T2, T3, T4>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5>(Type type, MethodBase method, Action<TOwner, T1, T2, T3, T4, T5> action)
        {
            AddInner<Action<TOwner, T1, T2, T3, T4, T5>, ActionInterceptor<TOwner, T1, T2, T3, T4, T5>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6>(Type type, MethodBase method, Action<TOwner, T1, T2, T3, T4, T5, T6> action)
        {
            AddInner<Action<TOwner, T1, T2, T3, T4, T5, T6>, ActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7>(Type type, MethodBase method, Action<TOwner, T1, T2, T3, T4, T5, T6, T7> action)
        {
            AddInner<Action<TOwner, T1, T2, T3, T4, T5, T6, T7>, ActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8>(Type type, MethodBase method, Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            AddInner<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8>, ActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Type type, MethodBase method, Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
        {
            AddInner<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9>, ActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Type type, MethodBase method, Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
        {
            AddInner<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, ActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Type type, MethodBase method, Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
        {
            AddInner<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, ActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Type type, MethodBase method, Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
        {
            AddInner<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, ActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Type type, MethodBase method, Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
        {
            AddInner<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, ActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Type type, MethodBase method, Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
        {
            AddInner<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, ActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(type, method, action);
        }

        public void Add<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Type type, MethodBase method, Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
        {
            AddInner<Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, ActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(type, method, action);
        }

        #endregion
    }
}