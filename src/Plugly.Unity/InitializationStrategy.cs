using Microsoft.Practices.ObjectBuilder2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Unity
{
    sealed class InitializationStrategy : BuilderStrategy
    {
        public override void PreBuildUp(IBuilderContext context)
        {
            var type = context.BuildKey.Type;
            Customizer.Current.InitializeInstance(type, context.Existing);
        }
    }
}
