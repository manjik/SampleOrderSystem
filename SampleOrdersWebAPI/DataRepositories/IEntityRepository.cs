﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.DataRepositories
{
    public interface IEntityRepository<T>
    {
        Task<List<T>> GetAllAsync();

        Task<int> Update(T item);

        Task<int> Create(T item);

        Task<int> Delete(T item);
    }
}
