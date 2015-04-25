using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Interceptors
{
    sealed class ProtectedActionInterceptor<TOwner>
            : ProtectedInterceptorBase<TOwner,
            Action<TOwner, Action>,
            Action<TOwner>>
    {
        protected override void Invoke(Action<TOwner, Action> action, IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target, baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TOwner Target;
            public Action<TOwner> Method;
            public void Invoke()
            {
                Method(Target);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, Action<T1>>,
            Action<TOwner, T1>>
    {
        protected override void Invoke(
            Action<TOwner, T1, Action<T1>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TOwner Target;
            public Action<TOwner, T1> Method;
            public void Invoke(T1 a1)
            {
                Method(Target, a1);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, Action<T1, T2>>,
            Action<TOwner, T1, T2>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, Action<T1, T2>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TOwner Target;
            public Action<TOwner, T1, T2> Method;
            public void Invoke(T1 a1, T2 a2)
            {
                Method(Target, a1, a2);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2, T3>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, T3, Action<T1, T2, T3>>,
            Action<TOwner, T1, T2, T3>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, T3, Action<T1, T2, T3>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TOwner Target;
            public Action<TOwner, T1, T2, T3> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3)
            {
                Method(Target, a1, a2, a3);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2, T3, T4>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, T3, T4, Action<T1, T2, T3, T4>>,
            Action<TOwner, T1, T2, T3, T4>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, T3, T4, Action<T1, T2, T3, T4>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
            action(baseInvoker.Target,
                (T1)invocation.GetArgumentValue(0),
                (T2)invocation.GetArgumentValue(1),
                (T3)invocation.GetArgumentValue(2),
                (T4)invocation.GetArgumentValue(3),
                baseInvoker.Invoke);
        }

        struct BaseMethod
        {
            public TOwner Target;
            public Action<TOwner, T1, T2, T3, T4> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4)
            {
                Method(Target, a1, a2, a3, a4);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2, T3, T4, T5>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, T3, T4, T5, Action<T1, T2, T3, T4, T5>>,
            Action<TOwner, T1, T2, T3, T4, T5>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, T3, T4, T5, Action<T1, T2, T3, T4, T5>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
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
            public TOwner Target;
            public Action<TOwner, T1, T2, T3, T4, T5> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
            {
                Method(Target, a1, a2, a3, a4, a5);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, T3, T4, T5, T6, Action<T1, T2, T3, T4, T5, T6>>,
            Action<TOwner, T1, T2, T3, T4, T5, T6>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, T3, T4, T5, T6, Action<T1, T2, T3, T4, T5, T6>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
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
            public TOwner Target;
            public Action<TOwner, T1, T2, T3, T4, T5, T6> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
            {
                Method(Target, a1, a2, a3, a4, a5, a6);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, Action<T1, T2, T3, T4, T5, T6, T7>>,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, Action<T1, T2, T3, T4, T5, T6, T7>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
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
            public TOwner Target;
            public Action<TOwner, T1, T2, T3, T4, T5, T6, T7> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, Action<T1, T2, T3, T4, T5, T6, T7, T8>>,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, Action<T1, T2, T3, T4, T5, T6, T7, T8>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
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
            public TOwner Target;
            public Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
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
            public TOwner Target;
            public Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
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
            public TOwner Target;
            public Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
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
            public TOwner Target;
            public Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
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
            public TOwner Target;
            public Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
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
            public TOwner Target;
            public Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13);
            }
        }
    }

    sealed class ProtectedActionInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        : ProtectedInterceptorBase<TOwner,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>,
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>
    {
        protected override void Invoke(
            Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> action,
            IInvocation invocation)
        {
            var baseInvoker = new BaseMethod { Target = (TOwner)invocation.Proxy, Method = baseMethod };
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
            public TOwner Target;
            public Action<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Method;
            public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14)
            {
                Method(Target, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14);
            }
        }
    }
}
