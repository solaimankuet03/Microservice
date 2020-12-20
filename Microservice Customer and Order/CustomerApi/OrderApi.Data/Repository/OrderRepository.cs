using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OrderApi.Domain;
using OrderApi.Data.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OrderApi.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext orderContext): base(orderContext) { }

        public async Task<List<Order>> GetOrderByCustomerGuidAsync(Guid customerId, CancellationToken cancellationToken)
        {
            return await orderContext.Order.Where(x => x.CustomerGuid == customerId).ToListAsync(cancellationToken);
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken)
        {
            return await orderContext.Order.FirstOrDefaultAsync(x => x.Id == orderId, cancellationToken);
        }

        public async Task<List<Order>> GetPaidOrdersAsync(CancellationToken cancellationToken)
        {
            return await orderContext.Order.Where(x => x.OrderState == 2).ToListAsync(cancellationToken);
        }
    }
}
