using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleOrdersWebAPI.Controllers;
using SampleOrdersWebAPI.Models;
using System.Collections.Generic;

namespace SampleOrdersWebAPI.Tests
{
    [TestClass]
    public class CustomersControllerTests
    {
        [TestMethod]
        public void GetAllCustomers_ShouldReturnAllCustomers()
        {

        }


        private List<Customer> GetTestCustomers()
        {
            var testCustomers = new List<Customer>();
            testCustomers.Add(new Customer { Id = 1, Name = "Test", Email = "test@email.com", Orders = null});

            return testCustomers;
        }
    }
}
