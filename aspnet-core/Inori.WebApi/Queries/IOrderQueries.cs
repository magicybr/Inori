using Inori.Domain.Models.Orders.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inori.WebApi.Queries
{
    public interface IOrderQueries
    {
        Task<Order> GetOrderAsync(int id);

        Task<IEnumerable<Order>> GetOrdersFromUserAsync(Guid userId);
    }
}
