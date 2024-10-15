using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace OKTECH.Models
{
    public class OrderRepository : IOrder
    {
        private readonly string _connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RJTECHDB;Integrated Security=True";

        public void Add(OrderDetail order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO OrderDetail 
                    (Id, PlacedAt, Name, Address, City, Country, PostalCode) 
                    VALUES (@Id, @PlacedAt, @Name, @Address, @City, @Country, @PostalCode);";

                connection.Execute(query, order);
            }
        }

        public OrderDetail getOrder(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM OrderDetail WHERE Id = @Id;";
                return connection.QuerySingleOrDefault<OrderDetail>(query, new { Id = id });
            }
        }
        public List<CartItems> getOrderProducts(string userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM CartItems WHERE UserId = @UserId;";
                return connection.Query<CartItems>(query, new { UserId = userId }).ToList();
            }
        }

        public void AddOrderProduct(List<OrderProduct> products)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO OrderProduct (OrderId, ProductId) VALUES (@OrderId, @ProductId);";
                connection.Execute(query, products);
            }
        }
        public void deleteCartItems(string userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM CartItems WHERE UserId = @UserId;";
                connection.Execute(query, new { UserId = userId });
            }
        }
    }
}