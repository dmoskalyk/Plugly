using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Tests.Data
{
    public class CustomerWrapper
    {
        Customer customer;

        public virtual string GetFullName()
        {
            return customer.FirstName + "/" + customer.LastName;
        }

        public CustomerWrapper(Customer customer)
        {
            this.customer = customer;
        }
    }
}
