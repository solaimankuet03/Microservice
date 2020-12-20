using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using OrderApi.Domain;

namespace OrderApi.Service.V1.Query
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}
