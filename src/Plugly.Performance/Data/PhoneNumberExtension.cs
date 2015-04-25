using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Performance.Data
{
    class PhoneNumberExtension : IPhoneNumberExtension
    {
        public string PhoneNumber { get; set; }

        [Customization]
        static string GetText(Address address)
        {
            var ext = (IPhoneNumberExtension)address;
            return address.GetText() + ", " + ext.PhoneNumber;
        }

        public static string AddPhoneNumber(string text, string phoneNumber)
        {
            return text + ", " + phoneNumber;
        }
    }

    public interface IPhoneNumberExtension
    {
        string PhoneNumber { get; set; }
    }
}
