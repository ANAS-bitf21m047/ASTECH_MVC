using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace OKTECH.Models
{
    public class CartRepository : ICart
    {
        private readonly string _connectionString;
        public CartRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CartItems GetItem(int productId, string userId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = @"
                    SELECT * FROM CartItems
                    WHERE ProductId = @ProductId AND UserId = @UserId;";

                return db.QueryFirstOrDefault<CartItems>(sql, new { ProductId = productId, UserId = userId });
            }
        }
        public void Add(CartItems cartItem)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = @"
                    INSERT INTO CartItems (ProductId, UserId, Name, Price, Discprice, Image, Category, Quantity)
                    VALUES (@ProductId, @UserId, @Name, @Price, @Discprice, @Image, @Category, @Quantity);";

                db.Execute(sql, cartItem);
            }
        }

        public void Update(CartItems cartItem)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = @"
                    UPDATE CartItems
                    SET Quantity = @Quantity
                    WHERE ProductId = @ProductId AND UserId = @UserId;";

                db.Execute(sql, new { Quantity = cartItem.Quantity, cartItem.ProductId, cartItem.UserId });
            }
        }

        public List<CartItems> GetItemsByUser(string userId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM CartItems WHERE UserId = @UserId;";
                return db.Query<CartItems>(sql, new { UserId = userId }).ToList();
            }
        }

        public void Remove(CartItems cartItem)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = @"
                    DELETE FROM CartItems
                    WHERE ProductId = @ProductId AND UserId = @UserId;";

                db.Execute(sql, new { cartItem.ProductId, cartItem.UserId });
            }
        }
    }
}
