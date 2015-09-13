using Microsoft.Practices.ObjectBuilder2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Unity
{
    sealed class CreationStrategy : BuilderStrategy
    {
        public override void PreBuildUp(IBuilderContext context)
        {
            var customizer = Customizer.Current;
            var type = context.BuildKey.Type;
            if (!customizer.IsCustomized(type))
                return;

            var instance = customizer.CreateInstance(type, parameters: GetParams(context), initialize: false);
            context.Existing = instance;
            if (customizer.ShouldBuildUp())
                return;

            customizer.InitializeInstance(type, instance);
            context.BuildComplete = true;
        }

        ConstructionParameters GetParams(IBuilderContext context)
        {
            var ctorSelector = context.Policies.Get<IConstructorSelectorPolicy>(context.BuildKey);
            var selectedCtor = ctorSelector.SelectConstructor(context, context.Policies);
            var types = selectedCtor.Constructor.GetParameters().Select(p => p.ParameterType).ToArray();
            var values = selectedCtor.GetParameterResolvers().Select(p => new Func<object>(() => p.Resolve(context))).ToArray();
            return new ConstructionParameters(types, values);
        }
    }
}
