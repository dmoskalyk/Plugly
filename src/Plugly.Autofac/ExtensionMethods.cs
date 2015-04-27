using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac
{
    public static class ExtensionMethods
    {
        public static IContainer EnableCustomizations(this IContainer container)
        {
            return Plugly.Autofac.Extension.Setup(container);
        }
    }
}
