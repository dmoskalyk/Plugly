using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public sealed partial class Customizer<TTarget>
    {
        #region Func registrations

        public Customizer<TTarget> Override<TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, T4, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, T4, T5, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, T4, T5, T6, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            Expression<Func<TTarget, TResult>> method,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        #endregion

        #region Action registrations

        public Customizer<TTarget> Override(
            Expression<Action<TTarget>> method,
            Action<TTarget> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3, T4> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3, T4, T5> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3, T4, T5, T6> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        public Customizer<TTarget> Override<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Expression<Action<TTarget>> method,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), with); return this;
        }

        #endregion
    }
}
