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
            var customersController = new TestCustomersController();
            
            var customersWithoutOrders = (await customersController.GetCustomerWithoutOrders()).Value.ToList();

            Assert.AreEqual("Test", customersWithoutOrders[0].Name);
        }
    }

    internal class TestCustomersController : CustomersController
    {
        public TestCustomersController()
        {
        }

        protected override ICustomersRepository GetRepository()
        {
            return new TestCustomersRepository();
        }
    }

    internal class TestCustomersRepository : ICustomersRepository
    {
        private async Task<List<Customer>> GetTestCustomers()
        {
            var testCustomers = new List<Customer>();
            testCustomers.Add(new Customer { Id = 1, Name = "Test", Email = "test@email.com", Orders = null });

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
