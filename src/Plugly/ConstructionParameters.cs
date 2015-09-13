using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public sealed class ConstructionParameters
    {
        public static readonly ConstructionParameters Empty = new ConstructionParameters(Type.EmptyTypes, new Func<object>[0]);

        public Type[] ParameterTypes { get; private set; }
        
        public Func<object>[] ParameterValues { get; private set; }

        public int ParameterCount
        {
            get { return ParameterTypes.Length; }
        }

        public ConstructionParameters(Type[] parameterTypes, Func<object>[] parameterValues)
        {
            if (parameterTypes.Length != parameterValues.Length)
                throw new ArgumentException("Parameter values count must be equal to parameter types count.");
            this.ParameterTypes = parameterTypes;
            this.ParameterValues = parameterValues;
        }

        public static ConstructionParameters FromValues(params object[] values)
        {
            var types = new Type[values.Length];
            var dynamicValues = new Func<object>[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                types[i] = value.GetType();
                dynamicValues[i] = () => value;
            }
            return new ConstructionParameters(types, dynamicValues);
        }

        public static ConstructionParameters FromValues(Type[] types, object[] values)
        {
            var dynamicValues = new Func<object>[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                dynamicValues[i] = () => value;
            }
            return new ConstructionParameters(types, dynamicValues);
        }
    }
}
