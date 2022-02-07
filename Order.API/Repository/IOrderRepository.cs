using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Repository
{
    public interface IOrderRepository:IRepository<Model.Order>
    {
        Task<ICollection<Model.Order>> GetAll();
        Task<Model.Order> GetOrderById(int OrderId);
        Task CreateOrder(Model.Order order);
        Task UpdateOrder(Model.Order order);
        Task DeleteOrder(int Id);
    }
}
