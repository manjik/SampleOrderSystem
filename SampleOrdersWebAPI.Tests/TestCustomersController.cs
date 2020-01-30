using SampleOrdersWebAPI.Controllers;
using SampleOrdersWebAPI.DataRepositories;
using SampleOrdersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleOrdersWebAPI.Tests
{
    class TestCustomersController : CustomersController
    {
        List<Customer> _testCutomers;

        public TestCustomersController()
        {
        }

        public TestCustomersController(List<Customer> testData)
        {
            _testCutomers = testData;
        }

        protected override ICustomersRepository GetRepository()
        {
            return new TestCustomersRepository(_testCutomers);
        }
    }
}
