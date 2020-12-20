using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using CustomerApi.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using CustomerApi.Data.Repository.V1;

namespace CustomerApi.Service.V1.Query
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery,Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerByIdAsync(request.Id, cancellationToken);
        }
    }
}
