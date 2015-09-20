using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    /// <summary>
    /// Instance construction parameters.
    /// </summary>
    public sealed class ConstructionParameters
    {
        /// <summary>
        /// The empty parameters.
        /// </summary>
        public static readonly ConstructionParameters Empty = new ConstructionParameters(Type.EmptyTypes, new Func<object>[0]);

        /// <summary>
        /// Gets the constructor parameter types.
        /// </summary>
        /// <value>
        /// The parameter types.
        /// </value>
        public Type[] ParameterTypes { get; private set; }

        /// <summary>
        /// Gets the constructor parameter values.
        /// </summary>
        /// <value>
        /// The parameter values.
        /// </value>
        public Func<object>[] ParameterValues { get; private set; }

        /// <summary>
        /// Gets the constructor parameter count.
        /// </summary>
        /// <value>
        /// The parameter count.
        /// </value>
        public int ParameterCount
        {
            get { return ParameterTypes.Length; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionParameters"/> class.
        /// </summary>
        /// <param name="parameterTypes">The constructor parameter types.</param>
        /// <param name="parameterValues">The constructor parameter values.</param>
        /// <exception cref="System.ArgumentException">Parameter values count must be equal to parameter types count.</exception>
        public ConstructionParameters(Type[] parameterTypes, Func<object>[] parameterValues)
        {
            if (parameterTypes.Length != parameterValues.Length)
                throw new ArgumentException("Parameter values count must be equal to parameter types count.");
            this.ParameterTypes = parameterTypes;
            this.ParameterValues = parameterValues;
        }

        /// <summary>
        /// Creates constructor parameters from the list of values.
        /// </summary>
        /// <param name="values">The constructor parameters.</param>
        /// <returns>Returns a new initialized instance of construction parameters.</returns>
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

        /// <summary>
        /// Creates parameters from the list of constructor parameters types and values.
        /// </summary>
        /// <param name="types">The constructor parameters types.</param>
        /// <param name="values">The constructor parameters values.</param>
        /// <returns>Returns a new initialized instance of construction parameters.</returns>
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
