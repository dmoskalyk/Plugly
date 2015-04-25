using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Performance.Data
{
    public class Address
    {
        public string Country { get; set; }

        public string City { get; set; }

        public virtual string GetText()
        {
            return Country + ", " + City;
        }

        public Address()
        {
            this.Country = "Imaginationland";
            this.City = "South Park";
        }
    }
}
