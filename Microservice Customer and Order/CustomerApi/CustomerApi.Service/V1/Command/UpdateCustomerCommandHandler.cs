using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using CustomerApi.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using CustomerApi.Data.Repository.V1;
using CustomerApi.Messaging.Send.Sender.V1;

namespace CustomerApi.Service.V1.Command
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomerUpdateSender customerUpdateSender;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, ICustomerUpdateSender customerUpdateSender)
        {
            this.customerRepository = customerRepository;
            this.customerUpdateSender = customerUpdateSender;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.UpdateAsync(request.Customer);

            customerUpdateSender.SendCustomer(customer);

            return customer;
        }
    }
}
