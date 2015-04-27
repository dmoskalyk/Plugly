using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plugly.Unity
{
    public sealed class Extension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Customizer.SetResolver(new TypeResolver(Container));
            Context.Strategies.AddNew<CreationStrategy>(UnityBuildStage.PreCreation);
            Context.Strategies.AddNew<InitializationStrategy>(UnityBuildStage.Initialization);
            Context.Registering += Context_Registering;
        }

        void Context_Registering(object sender, RegisterEventArgs e)
        {
            Customizer.Current.RemapType(e.TypeFrom, e.TypeTo);
        }
    }
}