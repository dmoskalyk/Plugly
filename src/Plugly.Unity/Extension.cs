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
            Context.Strategies.Add(new CreationStrategy(customizer), UnityBuildStage.PreCreation);
            Context.Strategies.Add(new InitializationStrategy(customizer), UnityBuildStage.Initialization);
            Context.Container.RegisterInstance(customizer);
            Context.Registering += Context_Registering;
        }

        void Context_Registering(object sender, RegisterEventArgs e)
        {
            customizer.RemapType(e.TypeFrom, e.TypeTo);
        }

        sealed class CreationStrategy : BuilderStrategy
        {
            Customizer customizer;

            public CreationStrategy(Customizer customizer)
            {
                this.customizer = customizer;
            }

            public override void PreBuildUp(IBuilderContext context)
            {
                var type = context.BuildKey.Type;
                if (!customizer.IsCustomized(type))
                    return;
                
                var instance = customizer.CreateInstance(type, initialize: false);
                context.Existing = instance;
                if (customizer.ShouldBuildUp(type))
                    customizer.InitializeInstance(type, instance);
                else
                    context.BuildComplete = true;
            }
        }

        sealed class InitializationStrategy : BuilderStrategy
        {
            Customizer customizer;

            public InitializationStrategy(Customizer customizer)
            {
                this.customizer = customizer;
            }

            public override void PreBuildUp(IBuilderContext context)
            {
                var type = context.BuildKey.Type;
                customizer.InitializeInstance(type, context.Existing);
            }
        }
    }
}