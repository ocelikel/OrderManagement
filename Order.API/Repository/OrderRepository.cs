using Microsoft.EntityFrameworkCore;
using Order.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Order.API.Repository
{
    public class OrderRepository : Repository<Model.Order>, IOrderRepository
    {
        public OrderRepository(OrderContext context):base(context)
        {

        }

        public async Task CreateOrder(Model.Order order)
        {
            await Insert(order);
        }

        public async Task UpdateOrder(Model.Order order)
        {
            await Update(order);
        }

        public async Task DeleteOrder(int Id)
        {
            var order = await GetOrderById(Id);
            await Update(order);
        }

        public async Task<ICollection<Model.Order>> GetAll()
        {
            return GetOrder().ToList();
        }

        public async Task<Model.Order> GetOrderById(int OrderId)
        {
            return await GetOrder(x => x.OrderId == OrderId ).FirstOrDefaultAsync();
        }

        private IQueryable<Model.Order> GetOrder(Expression<Func<Model.Order, bool>> filter = null)
        {
            return List(filter).Select(x => new Model.Order
            {
              CustomerAddress=x.CustomerAddress,
              CustomerName=x.CustomerName,
              OrderId=x.OrderId,
              OrderDetails=x.OrderDetails
            });
        }
      
    }
}
