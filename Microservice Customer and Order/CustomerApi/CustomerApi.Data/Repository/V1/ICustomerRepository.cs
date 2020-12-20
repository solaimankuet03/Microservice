﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CustomerApi.Domain.Entities;

namespace CustomerApi.Data.Repository.V1
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
