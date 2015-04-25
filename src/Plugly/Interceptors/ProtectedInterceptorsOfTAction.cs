using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Interceptors
{
    sealed class ProtectedActionInterceptor<TTarget>
            : ProtectedInterceptorBase<TTarget,
            Action<TTarget, Action>,
            Action<TTarget>>
    {
        protected override void Invoke(Action<TTarget, Action> action, IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target, baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Action<TTarget> Method;
            public void Invoke()
            {
                Method(Target);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, Action<T1>>,
            Action<TTarget, T1>>
    {
        protected override void Invoke(
            Action<TTarget, T1, Action<T1>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Action<TTarget, T1> Method;
            public void Invoke(T1 a1)
            {
                Method(Target, a1);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, Action<T1, T2>>,
            Action<TTarget, T1, T2>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, Action<T1, T2>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Action<TTarget, T1, T2> Method;
            public void Invoke(T1 a1, T2 a2)
            {
                Method(Target, a1, a2);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2, T3>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, T3, Action<T1, T2, T3>>,
            Action<TTarget, T1, T2, T3>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, T3, Action<T1, T2, T3>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Action<TTarget, T1, T2, T3> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3)
            {
                Method(Target, a1, a2, a3);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2, T3, T4>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, T3, T4, Action<T1, T2, T3, T4>>,
            Action<TTarget, T1, T2, T3, T4>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, T3, T4, Action<T1, T2, T3, T4>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TTarget Target;
            public Action<TTarget, T1, T2, T3, T4> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4)
            {
                Method(Target, a1, a2, a3, a4);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2, T3, T4, T5>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, T3, T4, T5, Action<T1, T2, T3, T4, T5>>,
            Action<TTarget, T1, T2, T3, T4, T5>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, T3, T4, T5, Action<T1, T2, T3, T4, T5>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
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
            public Action<TTarget, T1, T2, T3, T4, T5> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
            {
                Method(Target, a1, a2, a3, a4, a5);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, T3, T4, T5, T6, Action<T1, T2, T3, T4, T5, T6>>,
            Action<TTarget, T1, T2, T3, T4, T5, T6>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, T3, T4, T5, T6, Action<T1, T2, T3, T4, T5, T6>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
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
            public Action<TTarget, T1, T2, T3, T4, T5, T6> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
            {
                Method(Target, a1, a2, a3, a4, a5, a6);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, Action<T1, T2, T3, T4, T5, T6, T7>>,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, Action<T1, T2, T3, T4, T5, T6, T7>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
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
            public Action<TTarget, T1, T2, T3, T4, T5, T6, T7> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, Action<T1, T2, T3, T4, T5, T6, T7, T8>>,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, Action<T1, T2, T3, T4, T5, T6, T7, T8>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
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
            public Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
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
            public Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
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
            public Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
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
            public Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
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
            public Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
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
            public Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        : ProtectedInterceptorBase<TTarget,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>,
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>
    {
        protected override void Invoke(
            Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TTarget)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
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
            public Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14);
            }
        }
    }
}
