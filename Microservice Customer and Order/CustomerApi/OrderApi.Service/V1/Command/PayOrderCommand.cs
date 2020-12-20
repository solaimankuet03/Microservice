using MediatR;
using OrderApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.Service.V1.Command
{
    public class PayOrderCommand : IRequest<Order>
    {
        public Order order { get; set; }
    }
}
