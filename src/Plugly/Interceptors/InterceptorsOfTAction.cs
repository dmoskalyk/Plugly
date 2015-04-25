using Castle.DynamicProxy;
using Plugly.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plugly.Interceptors
{
    sealed class ActionInterceptor<TTarget> : InterceptorBase<Action<TTarget>>
    {
        protected sealed override void Invoke(Action<TTarget> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy);
        }
    }

    sealed class ActionInterceptor<TTarget, T1> : InterceptorBase<Action<TTarget, T1>>
    {
        protected sealed override void Invoke(Action<TTarget, T1> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy, (T1)invocation.GetArgumentValue(0));
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2> : InterceptorBase<Action<TTarget, T1, T2>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3> : InterceptorBase<Action<TTarget, T1, T2, T3>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3, T4> : InterceptorBase<Action<TTarget, T1, T2, T3, T4>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3, T4> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3, T4, T5> : InterceptorBase<Action<TTarget, T1, T2, T3, T4, T5>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3, T4, T5> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6> : InterceptorBase<Action<TTarget, T1, T2, T3, T4, T5, T6>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3, T4, T5, T6> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
                , (T6)invocation.GetArgumentValue(5)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7> : InterceptorBase<Action<TTarget, T1, T2, T3, T4, T5, T6, T7>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3, T4, T5, T6, T7> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
                , (T6)invocation.GetArgumentValue(5)
                , (T7)invocation.GetArgumentValue(6)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8> : InterceptorBase<Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
                , (T6)invocation.GetArgumentValue(5)
                , (T7)invocation.GetArgumentValue(6)
                , (T8)invocation.GetArgumentValue(7)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9> : InterceptorBase<Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
                , (T6)invocation.GetArgumentValue(5)
                , (T7)invocation.GetArgumentValue(6)
                , (T8)invocation.GetArgumentValue(7)
                , (T9)invocation.GetArgumentValue(8)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : InterceptorBase<Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
                , (T6)invocation.GetArgumentValue(5)
                , (T7)invocation.GetArgumentValue(6)
                , (T8)invocation.GetArgumentValue(7)
                , (T9)invocation.GetArgumentValue(8)
                , (T10)invocation.GetArgumentValue(9)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : InterceptorBase<Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
                , (T6)invocation.GetArgumentValue(5)
                , (T7)invocation.GetArgumentValue(6)
                , (T8)invocation.GetArgumentValue(7)
                , (T9)invocation.GetArgumentValue(8)
                , (T10)invocation.GetArgumentValue(9)
                , (T11)invocation.GetArgumentValue(10)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : InterceptorBase<Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
                , (T6)invocation.GetArgumentValue(5)
                , (T7)invocation.GetArgumentValue(6)
                , (T8)invocation.GetArgumentValue(7)
                , (T9)invocation.GetArgumentValue(8)
                , (T10)invocation.GetArgumentValue(9)
                , (T11)invocation.GetArgumentValue(10)
                , (T12)invocation.GetArgumentValue(11)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : InterceptorBase<Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
                , (T6)invocation.GetArgumentValue(5)
                , (T7)invocation.GetArgumentValue(6)
                , (T8)invocation.GetArgumentValue(7)
                , (T9)invocation.GetArgumentValue(8)
                , (T10)invocation.GetArgumentValue(9)
                , (T11)invocation.GetArgumentValue(10)
                , (T12)invocation.GetArgumentValue(11)
                , (T13)invocation.GetArgumentValue(12)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : InterceptorBase<Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
                , (T6)invocation.GetArgumentValue(5)
                , (T7)invocation.GetArgumentValue(6)
                , (T8)invocation.GetArgumentValue(7)
                , (T9)invocation.GetArgumentValue(8)
                , (T10)invocation.GetArgumentValue(9)
                , (T11)invocation.GetArgumentValue(10)
                , (T12)invocation.GetArgumentValue(11)
                , (T13)invocation.GetArgumentValue(12)
                , (T14)invocation.GetArgumentValue(13)
            );
        }
    }

    sealed class ActionInterceptor<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : InterceptorBase<Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>
    {
        protected sealed override void Invoke(Action<TTarget, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, IInvocation invocation)
        {
            action((TTarget)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
                , (T6)invocation.GetArgumentValue(5)
                , (T7)invocation.GetArgumentValue(6)
                , (T8)invocation.GetArgumentValue(7)
                , (T9)invocation.GetArgumentValue(8)
                , (T10)invocation.GetArgumentValue(9)
                , (T11)invocation.GetArgumentValue(10)
                , (T12)invocation.GetArgumentValue(11)
                , (T13)invocation.GetArgumentValue(12)
                , (T14)invocation.GetArgumentValue(13)
                , (T15)invocation.GetArgumentValue(14)
            );
        }
    }
}