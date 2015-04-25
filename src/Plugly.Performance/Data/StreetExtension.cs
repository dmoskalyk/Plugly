using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Performance.Data
{
    class StreetExtension : IStreetExtension
    {
        public string Street { get; set; }

        [Customization]
        static string GetText(Address address)
        {
            var ext = (IStreetExtension)address;
            return address.GetText() + ", " + ext.Street;
        }

        public static string AddStreet(string text, string street)
        {
            return text + ", " + street;
        }
    }

    public interface IStreetExtension
    {
        string Street { get; set; }
    }
}
