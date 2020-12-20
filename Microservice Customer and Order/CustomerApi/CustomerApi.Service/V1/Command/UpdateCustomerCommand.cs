﻿using CustomerApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.Service.V1.Command
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public Customer Customer { get; set; }
    }
}
