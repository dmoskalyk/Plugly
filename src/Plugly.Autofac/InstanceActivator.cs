using Autofac;
using Autofac.Core;
using Autofac.Core.Activators.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Autofac
{
    sealed class InstanceActivator : IInstanceActivator
    {
        static FieldInfo _defaultParametersField = typeof(ReflectionActivator).GetField("_defaultParameters", BindingFlags.Instance | BindingFlags.NonPublic);
        static FieldInfo _valueRetrieversField = typeof(ConstructorParameterBinding).GetField("_valueRetrievers", BindingFlags.Instance | BindingFlags.NonPublic);
        
        IInstanceActivator activator;
        IConstructorFinder constructorFinder;
        IConstructorSelector constructorSelector;
        IEnumerable<Parameter> _defaultParameters;

        public InstanceActivator(IInstanceActivator activator)
        {
            this.activator = activator;
            var reflectionActivator = activator as ReflectionActivator;
            if (reflectionActivator != null)
            {
                this.constructorFinder = reflectionActivator.ConstructorFinder;
                this.constructorSelector = reflectionActivator.ConstructorSelector;
                this._defaultParameters = (IEnumerable<Parameter>)_defaultParametersField.GetValue(reflectionActivator);
            }
            else
            {
                this.constructorFinder = new DefaultConstructorFinder();
                this.constructorSelector = new MostParametersConstructorSelector();
                this._defaultParameters = new Parameter[] { new AutowiringParameter(), new DefaultValueParameter() };
            }
        }

        public object ActivateInstance(IComponentContext context, IEnumerable<Parameter> parameters)
        {
            var customizer = Customizer.Current;
            if (customizer.IsCustomized(LimitType))
                return customizer.CreateInstance(activator.LimitType, GetParams(context, parameters));
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

        ConstructionParameters GetParams(IComponentContext context, IEnumerable<Parameter> parameters)
        {
            var availableParameters = parameters.Concat(_defaultParameters);
            var bindings = constructorFinder.FindConstructors(LimitType)
                .Select(c => new ConstructorParameterBinding(c, availableParameters, context))
                .ToArray();
            var binding = constructorSelector.SelectConstructorBinding(bindings);
            var types = binding.TargetConstructor.GetParameters().Select(p => p.ParameterType).ToArray();
            var values = (Func<object>[])_valueRetrieversField.GetValue(binding);
            return new ConstructionParameters(types, values);
        }
    }
}
