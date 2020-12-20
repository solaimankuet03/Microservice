using System;
using System.Collections.Generic;
using System.Text;
using CustomerApi.Domain.Entities;

namespace CustomerApi.Messaging.Send.Sender.V1
{
    public interface ICustomerUpdateSender
    {
        void SendCustomer(Customer customer);
    }
}
