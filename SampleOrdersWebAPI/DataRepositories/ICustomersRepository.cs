using SampleOrdersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.DataRepositories
{
    public interface ICustomersRepository : IEntityRepository<Customer>
    {
    }
}
