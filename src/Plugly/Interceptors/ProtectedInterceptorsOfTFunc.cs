using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Interceptors
{
    sealed class ProtectedFuncInterceptor<TTarget, TResult>
        : ProtectedInterceptorBase<TTarget, 
        Func<TTarget, Func<TResult>, TResult>, 
        Func<TTarget, TResult>>
    {
        protected override void Invoke(Func<TTarget, Func<TResult>, TResult> action, IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target, baseInvoker.Invoke);
        }

        struct BaseMethod {
            public TTarget Target; 
            public Func<TTarget, TResult> Method; 
            public TResult Invoke() { 
                return Method(Target);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, Func<T1, TResult>, TResult>,
            Func<TTarget, T1, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, Func<T1, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, TResult> Method;
            public TResult Invoke(T1 a1)
            {
                return Method(Target, a1);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, T2, Func<T1, T2, TResult>, TResult>,
            Func<TTarget, T1, T2, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, Func<T1, T2, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2)
            {
                return Method(Target, a1, a2);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, T3, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, T2, T3, Func<T1, T2, T3, TResult>, TResult>,
            Func<TTarget, T1, T2, T3, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, T3, Func<T1, T2, T3, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, T3, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2, T3 a3)
            {
                return Method(Target, a1, a2, a3);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, T3, T4, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, T2, T3, T4, Func<T1, T2, T3, T4, TResult>, TResult>,
            Func<TTarget, T1, T2, T3, T4, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, T3, T4, Func<T1, T2, T3, T4, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, T3, T4, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2, T3 a3, T4 a4)
            {
                return Method(Target, a1, a2, a3, a4);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, T3, T4, T5, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, T2, T3, T4, T5, Func<T1, T2, T3, T4, T5, TResult>, TResult>,
            Func<TTarget, T1, T2, T3, T4, T5, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, T3, T4, T5, Func<T1, T2, T3, T4, T5, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                (T5)invocation.GetArgumentValue(4),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, T3, T4, T5, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
            {
                return Method(Target, a1, a2, a3, a4, a5);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, T3, T4, T5, T6, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, T2, T3, T4, T5, T6, Func<T1, T2, T3, T4, T5, T6, TResult>, TResult>,
            Func<TTarget, T1, T2, T3, T4, T5, T6, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, T3, T4, T5, T6, Func<T1, T2, T3, T4, T5, T6, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                (T5)invocation.GetArgumentValue(4),
                (T6)invocation.GetArgumentValue(5),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, T3, T4, T5, T6, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
            {
                return Method(Target, a1, a2, a3, a4, a5, a6);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, Func<T1, T2, T3, T4, T5, T6, T7, TResult>, TResult>,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, Func<T1, T2, T3, T4, T5, T6, T7, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                (T5)invocation.GetArgumentValue(4),
                (T6)invocation.GetArgumentValue(5),
                (T7)invocation.GetArgumentValue(6),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, T3, T4, T5, T6, T7, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
            {
                return Method(Target, a1, a2, a3, a4, a5, a6, a7);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, TResult>,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                (T5)invocation.GetArgumentValue(4),
                (T6)invocation.GetArgumentValue(5),
                (T7)invocation.GetArgumentValue(6),
                (T8)invocation.GetArgumentValue(7),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)
            {
                return Method(Target, a1, a2, a3, a4, a5, a6, a7, a8);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, TResult>,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                (T5)invocation.GetArgumentValue(4),
                (T6)invocation.GetArgumentValue(5),
                (T7)invocation.GetArgumentValue(6),
                (T8)invocation.GetArgumentValue(7),
                (T9)invocation.GetArgumentValue(8),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9)
            {
                return Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>, TResult>,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                (T5)invocation.GetArgumentValue(4),
                (T6)invocation.GetArgumentValue(5),
                (T7)invocation.GetArgumentValue(6),
                (T8)invocation.GetArgumentValue(7),
                (T9)invocation.GetArgumentValue(8),
                (T10)invocation.GetArgumentValue(9),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10)
            {
                return Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>, TResult>,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                (T5)invocation.GetArgumentValue(4),
                (T6)invocation.GetArgumentValue(5),
                (T7)invocation.GetArgumentValue(6),
                (T8)invocation.GetArgumentValue(7),
                (T9)invocation.GetArgumentValue(8),
                (T10)invocation.GetArgumentValue(9),
                (T11)invocation.GetArgumentValue(10),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11)
            {
                return Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>, TResult>,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                (T5)invocation.GetArgumentValue(4),
                (T6)invocation.GetArgumentValue(5),
                (T7)invocation.GetArgumentValue(6),
                (T8)invocation.GetArgumentValue(7),
                (T9)invocation.GetArgumentValue(8),
                (T10)invocation.GetArgumentValue(9),
                (T11)invocation.GetArgumentValue(10),
                (T12)invocation.GetArgumentValue(11),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12)
            {
                return Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
        : ProtectedInterceptorBase<TTarget,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>, TResult>,
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>, TResult> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                (T5)invocation.GetArgumentValue(4),
                (T6)invocation.GetArgumentValue(5),
                (T7)invocation.GetArgumentValue(6),
                (T8)invocation.GetArgumentValue(7),
                (T9)invocation.GetArgumentValue(8),
                (T10)invocation.GetArgumentValue(9),
                (T11)invocation.GetArgumentValue(10),
                (T12)invocation.GetArgumentValue(11),
                (T13)invocation.GetArgumentValue(12),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13)
            {
                return Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13);
            }
        }
    }

    sealed class ProtectedFuncInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
        : ProtectedInterceptorBase<TTarget, 
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>, TResult>, 
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>>
    {
        protected override void Invoke(
            Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>, TResult> action, 
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            invocation.ReturnValue = action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                (T5)invocation.GetArgumentValue(4),
                (T6)invocation.GetArgumentValue(5),
                (T7)invocation.GetArgumentValue(6),
                (T8)invocation.GetArgumentValue(7),
                (T9)invocation.GetArgumentValue(8),
                (T10)invocation.GetArgumentValue(9),
                (T11)invocation.GetArgumentValue(10),
                (T12)invocation.GetArgumentValue(11),
                (T13)invocation.GetArgumentValue(12),
                (T14)invocation.GetArgumentValue(13),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Func<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Method;
            public TResult Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14) {
                return Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14);
            }
        }
    }
}
