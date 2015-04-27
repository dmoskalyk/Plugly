using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Tests
{
    public abstract class TestsBase
    {
        protected Customizer customizer;

        [TestInitialize]
        public void TestInitialize()
        {
            customizer = new Customizer();
            Customizer.SetLocator(new SingleCustomizerLocator(customizer));
            Customizer.SetResolver(new DefaultTypeResolver());
            Initialize();
        }

        protected virtual void Initialize()
        {
        }
    }
}
