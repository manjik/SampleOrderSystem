using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleOrdersWebAPI.Controllers;
using SampleOrdersWebAPI.DataRepositories;
using SampleOrdersWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.Tests
{
    [TestClass]
    public class CustomersControllerTests
    {
        [TestMethod]
        public async Task GetNoOrdersCustomers_ShouldReturnAllCustomersWithoutOrdersAsync()
        {
            var testData = new List<Customer>();
            testData.Add(new Customer { Id = 1, Name = "TestNoOrder", Email = "test_no_order@email.com", Orders = null });
            testData.Add(new Customer { Id = 2, Name = "TestOrder", Email = "test_order@email.com", Orders = null });

            var customersController = new TestCustomersController(testData);
            
            var customersWithoutOrders = (await customersController.GetCustomerWithoutOrders()).Value.ToList();

            Assert.AreEqual(2, customersWithoutOrders.Count);
            Assert.AreEqual("TestNoOrder", customersWithoutOrders[0].Name);
        }
    }

    internal class TestCustomersController : CustomersController
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

    internal class TestCustomersRepository : ICustomersRepository
    {
        List<Customer> _testCutomers;

        public TestCustomersRepository()
        {
        }

        public TestCustomersRepository(List<Customer> testData)
        {
            _testCutomers = testData;
        }

        private async Task<List<Customer>> GetTestCustomers()
        {
            var testCustomers = new List<Customer>();
            
            foreach (Customer customer in _testCutomers)
                testCustomers.Add(customer);

            return testCustomers;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await GetTestCustomers();
        }

        public Task<int> Update(Customer item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Create(Customer item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(Customer item)
        {
            throw new System.NotImplementedException();
        }
    }
}
