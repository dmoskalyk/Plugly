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

            var instance = customizer.CreateInstance(type, initialize: false);
            context.Existing = instance;
            if (customizer.ShouldBuildUp())
                return;

            customizer.InitializeInstance(type, instance);
            context.BuildComplete = true;
        }
    }
}
