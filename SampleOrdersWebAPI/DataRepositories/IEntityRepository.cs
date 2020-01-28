using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.DataRepositories
{
    public interface IEntityRepository<T>
    {
        Task<List<T>> GetAllAsync();

        Task<IActionResult> Update(T item);
    }
}
