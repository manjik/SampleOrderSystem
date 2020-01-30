using SampleOrdersWebAPI.DataRepositories;
using SampleOrdersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.Tests
{
    class TestCustomersRepository : ICustomersRepository
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
