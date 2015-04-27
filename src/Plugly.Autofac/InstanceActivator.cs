using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Autofac
{
    public sealed class InstanceActivator : IInstanceActivator
    {
        IInstanceActivator activator;

        public InstanceActivator(IInstanceActivator activator)
        {
            this.activator = activator;
        }

        public object ActivateInstance(IComponentContext context, IEnumerable<Parameter> parameters)
        {
            var customizer = Customizer.Current;
            if (customizer.IsCustomized(LimitType))
                return customizer.CreateInstance(activator.LimitType);
            else
                return activator.ActivateInstance(context, parameters);
        }

        public Type LimitType
        {
            get { return activator.LimitType; }
        }

        public void Dispose()
        {
            activator.Dispose();
        }
    }
}
