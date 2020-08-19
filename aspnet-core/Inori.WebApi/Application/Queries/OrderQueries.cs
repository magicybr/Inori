using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inori.WebApi.Application.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private string _connectionString = string.Empty;
        public OrderQueries(string connStr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connStr) ? connStr : throw new ArgumentNullException(nameof(connStr));
        }
        public async Task<Order> GetOrderAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(@"", new { id });

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapOrderItems(result);
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersFromUserAsync(Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<Order>("");
            }
        }

        private Order MapOrderItems(dynamic result)
        {
            var order = new Order { 

            };

            return order;
        }
    }
}
