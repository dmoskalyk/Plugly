using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plugly.Interceptors
{
    sealed class FuncInterceptor<TOwner, TResult> : InterceptorBase<Func<TOwner, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy);
        }
    }

    sealed class FuncInterceptor<TOwner, T1, TResult> : InterceptorBase<Func<TOwner, T1, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy, (T1)invocation.GetArgumentValue(0));
        }
    }

    sealed class FuncInterceptor<TOwner, T1, T2, TResult> : InterceptorBase<Func<TOwner, T1, T2, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
            );
        }
    }

    sealed class FuncInterceptor<TOwner, T1, T2, T3, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
            );
        }
    }

    sealed class FuncInterceptor<TOwner, T1, T2, T3, T4, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, T4, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, T4, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
            );
        }
    }

    sealed class FuncInterceptor<TOwner, T1, T2, T3, T4, T5, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, T4, T5, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, T4, T5, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
            );
        }
    }

    sealed class FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, T4, T5, T6, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, T4, T5, T6, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
                , (T1)invocation.GetArgumentValue(0)
                , (T2)invocation.GetArgumentValue(1)
                , (T3)invocation.GetArgumentValue(2)
                , (T4)invocation.GetArgumentValue(3)
                , (T5)invocation.GetArgumentValue(4)
                , (T6)invocation.GetArgumentValue(5)
            );
        }
    }

    sealed class FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, T4, T5, T6, T7, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
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

    sealed class FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
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

    sealed class FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
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

    sealed class FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
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

    sealed class FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
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

    sealed class FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
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

    sealed class FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
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

    sealed class FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
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

    sealed class FuncInterceptor<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> : InterceptorBase<Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>>
    {
        protected sealed override void Invoke(Func<TOwner, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> action, IInvocation invocation)
        {
            invocation.ReturnValue = action((TOwner)invocation.Proxy
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