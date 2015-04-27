using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public static class CustomizerExtensions
    {
        const string Key = "Unity.NoBuildUp";

        public static Customizer SetBuildUp(this Customizer customizer, bool shouldBuildUp = true)
        {
            if (shouldBuildUp)
                customizer.ExtraData.Remove(Key);
            else
                customizer.ExtraData[Key] = null;
            return customizer;
        }

        public static bool ShouldBuildUp(this Customizer customizer)
        {
            return !customizer.ExtraData.ContainsKey(Key);
        }
    }
}
