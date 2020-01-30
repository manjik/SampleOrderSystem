using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleOrdersWebAPI.Controllers;
using SampleOrdersWebAPI.DataRepositories;
using SampleOrdersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.Tests
{
    [TestClass]
    public class CustomersControllerTests
    {
        [TestMethod]
        public async Task GetNoOrdersCustomersForCustomersWithAndWithoutOrders_ShouldReturnAllCustomersWithoutOrders()
        {
            var testCustomers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "TestNoOrder", Email = "test_no_order@email.com", Orders = null},
                new Customer { Id = 2, Name = "TestOrder", Email = "test_order@email.com",
                    Orders = new List<Order> { new Order { Id = 1, CustomerId = 1, Price = 1, CreatedDate = DateTime.Today } } }
            };

            var customersController = new TestCustomersController(testCustomers);
            
            var customersWithoutOrders = (await customersController.GetCustomerWithoutOrders()).Value.ToList();

            Assert.AreEqual(1, customersWithoutOrders.Count);
            Assert.AreEqual("TestNoOrder", customersWithoutOrders[0].Name);
        }

        [TestMethod]
        public async Task GetNoOrdersCustomersForCustomersWithoutOrders_ShouldReturnAllCustomersWithoutOrders()
        {
            var testCustomers = new List<Customer>();
            testCustomers.Add(new Customer { Id = 1, Name = "TestNoOrder", Email = "test_no_order@email.com", Orders = null });
            testCustomers.Add(new Customer { Id = 2, Name = "TestNoOrder2", Email = "test_order@email.com", Orders = null });

            var customersController = new TestCustomersController(testCustomers);

            var customersWithoutOrders = (await customersController.GetCustomerWithoutOrders()).Value.ToList();

            Assert.AreEqual(2, customersWithoutOrders.Count);
            Assert.AreEqual("TestNoOrder", customersWithoutOrders[0].Name);
            Assert.AreEqual("TestNoOrder2", customersWithoutOrders[1].Name);
        }

        [TestMethod]
        public async Task GetNoOrdersCustomersForCustomersWithOrders_ShouldReturnEmptyList()
        {
            var testCustomers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "TestNoOrder", Email = "test_no_order@email.com",
                                Orders = new List<Order> {new Order { Id = 1, CustomerId = 1, Price = 1, CreatedDate = DateTime.Today} } },
                new Customer { Id = 2, Name = "TestOrder", Email = "test_order@email.com",
                                Orders = new List<Order> { new Order { Id = 1, CustomerId = 1, Price = 1, CreatedDate = DateTime.Today } } }
            };

            var customersController = new TestCustomersController(testCustomers);

            var customersWithoutOrders = (await customersController.GetCustomerWithoutOrders()).Value.ToList();

            Assert.AreEqual(0, customersWithoutOrders.Count);
        }

        [TestMethod]
        public async Task GetNoOrdersCustomersForEmptyList_ShouldReturnEmptyList()
        {
            var testCustomers = new List<Customer>();

            var customersController = new TestCustomersController(testCustomers);

            var customersWithoutOrders = (await customersController.GetCustomerWithoutOrders()).Value.ToList();

            Assert.AreEqual(0, customersWithoutOrders.Count);
        }
    }
}
