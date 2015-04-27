using Castle.DynamicProxy;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    sealed class CustomClassProxyGenerator : ClassProxyGenerator
    {
        static MethodInfo initProxyMethod = typeof(Customizer).GetMethod("InitializeProxy", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        static ConstructorInfo deserializingAttribute = typeof(OnDeserializingAttribute).GetConstructor(Type.EmptyTypes);

        public CustomClassProxyGenerator(ModuleScope scope, Type targetType) : base(scope, targetType)
        {
        }

        protected override void CreateFields(ClassEmitter emitter)
        {
            base.CreateFields(emitter);

            var method = emitter.CreateMethod("__deserialize", MethodAttributes.Public | MethodAttributes.HideBySig, typeof(void), typeof(System.Runtime.Serialization.StreamingContext));
            method.MethodBuilder.SetCustomAttribute(new CustomAttributeBuilder(deserializingAttribute, new object[0]));
            var il = method.MethodBuilder.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.EmitCall(OpCodes.Call, initProxyMethod.MakeGenericMethod(targetType), null);
        }
    }
}
