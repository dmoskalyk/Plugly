using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Tests.Data
{
    public class Customer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual string GetFullName(string format)
        {
            return string.Format(format, FirstName, GetMiddleName(), LastName);
        }

        protected virtual string GetMiddleName()
        {
            return "_";
        }

        public virtual void CopyTo(Customer other, string suffix)
        {
            other.FirstName = this.FirstName + suffix;
            other.LastName = this.LastName + suffix;
        }

        public Customer()
        {
            this.FirstName = "first";
            this.LastName = "last";
        }

        private string PrivateMethod()
        {
            return null;
        }
    }
}
