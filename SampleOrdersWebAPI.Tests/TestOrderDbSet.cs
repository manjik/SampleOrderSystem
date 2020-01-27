using SampleOrdersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleOrdersWebAPI.Tests
{
    public class TestOrderDbSet: TestDbSet<Order>
    {
        public override Order Find(params object[] keyValues)
        {
            return this.SingleOrDefault(order => order.Id == (int)keyValues.Single());
        }
    }
}
