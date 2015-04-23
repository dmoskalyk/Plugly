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
        Customizer customizer;

        protected override void Initialize()
        {
            this.customizer = new Customizer(new TypeResolver(Container));
            Context.Strategies.Add(new Strategy(customizer), UnityBuildStage.PreCreation);
            Context.Container.RegisterInstance(customizer);
            Context.Registering += Context_Registering;
        }

        void Context_Registering(object sender, RegisterEventArgs e)
        {
            customizer.RemapType(e.TypeFrom, e.TypeTo);
        }

        sealed class Strategy : BuilderStrategy
        {
            Customizer customizer;

            public Strategy(Customizer customizer)
            {
                this.customizer = customizer;
            }

            public override void PreBuildUp(IBuilderContext context)
            {
                var type = context.BuildKey.Type;
                if (!customizer.IsCustomized(type))
                    return;
                
                context.Existing = customizer.CreateInstance(type);
                if (customizer.ShouldBuildUp(type))
                    return;
                
                context.BuildComplete = true;
            }
        }
    }
}