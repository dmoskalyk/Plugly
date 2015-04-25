﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public sealed partial class Customizer<TOwner>
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

        public Customizer<TOwner> InitializeWith(Action<TOwner> action)
        {
            config.AddInitializer(ownerType, action);
            return this;
        }

        private MethodInfo GetMethod(LambdaExpression method)
        {
            var methodCall = method.Body as MethodCallExpression;
            if (methodCall == null)
                throw new ArgumentException("The provided expression must be a method call expression.", "method");

            if (!methodCall.Method.IsVirtual)
                throw new InvalidOperationException("Only virtual methods can be customized.");

            return methodCall.Method;
        }
    }
}
