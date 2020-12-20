using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using CustomerApi.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using CustomerApi.Data.Repository.V1;

namespace CustomerApi.Service.V1.Command
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await customerRepository.AddAsync(request.Customer);
        }
    }
}
