using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Tests.Data
{
    public class Address
    {
        public virtual string Country { get; set; }

        public virtual string City { get; set; }

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
