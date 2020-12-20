using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using CustomerApi.Domain.Entities;

namespace CustomerApi.Service.V1.Query
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public Guid Id { get; set; }
    }
}
