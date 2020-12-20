using OrderApi.Service.V1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Diagnostics;
using OrderApi.Service.V1.Command;
using OrderApi.Service.V1.Query;
using OrderApi.Domain;

namespace OrderApi.Service.V1.Services
{
    public class CustomerNameUpdateService : ICustomerNameUpdateService
    {
        private readonly IMediator mediator;

        public CustomerNameUpdateService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async void UpdateCustomerNameInOrders(UpdateCustomerFullNameModel updateCustomerFullNameModel)
        {
            try
            {
                var ordersOfCustomer = await mediator.Send(new GetOrderByCustomerGuidQuery
                {
                    CustomerId = updateCustomerFullNameModel.Id
                });

                if (ordersOfCustomer.Count != 0)
                {
                    ordersOfCustomer.ForEach(x => x.CustomerFullName = $"{updateCustomerFullNameModel.FirstName}{updateCustomerFullNameModel.LastName}");
                }

                await mediator.Send(new UpdateOrderCommand()
                {
                    Orders = ordersOfCustomer
                });
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
