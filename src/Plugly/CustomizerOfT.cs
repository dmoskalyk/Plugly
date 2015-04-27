using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public sealed partial class Customizer<TTarget>
    {
        Customizer parent;
        Type targetType;
        Configuration config;

        internal Customizer(Customizer parent, Configuration config, Type targetType)
        {
            this.parent = parent;
            this.config = config;
            this.targetType = targetType;
        }

        public Customizer<TOther> Setup<TOther>()
            where TOther : class
        {
            return parent.Setup<TOther>();
        }

        public Customizer<TTarget> InitializeWith(Action<TTarget> action)
        {
            config.AddInitializer(targetType, action);
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
