using SampleOrdersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleOrdersWebAPI.Tests
{
    public class TestCustomerDbSet: TestDbSet<Customer>
    {
        public override Customer Find(params object[] keyValues)
        {
            return this.SingleOrDefault(customer => customer.Id == (int)keyValues.Single());
        }
    }
}
