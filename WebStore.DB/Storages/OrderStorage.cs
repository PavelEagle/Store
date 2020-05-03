using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Core.ConfigurationOptions;
using WebStore.DB.Models;

namespace WebStore.DB.Storages
{
    public class OrderStorage : IOrderStorage
    {
        private IDbConnection connection;
        private IDbTransaction transaction;

        public OrderStorage(IOptions<StorageOptions> storageOptions)
        {
            connection = new SqlConnection(storageOptions.Value.DBConnectionString);
        }

        internal static class SpName
        {
            public const string OrderGetById = "Order_GetById";
            public const string OrderInsert = "Order_Insert";
        }


        public async ValueTask<OrderInfo> OrderGetById(int orderId)
        {
            try
            {
                var result = await connection.QueryAsync<City, Store, Product, OrderInfo, OrderInfo>(
                    SpName.OrderGetById,
                    (city, store, product, orderinfo) =>
                    {
                        OrderInfo newOrderInfo = orderinfo;
                        orderinfo.Store = store;
                        store.City = city;
                        newOrderInfo.Product = product;
                        return newOrderInfo;
                    },
                    new { orderId },
                    transaction: transaction,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");
                return result.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<OrderInfo> OrderInser(OrderInfo order)
        {
            try
            {
                var result = await connection.QueryAsync<long>(
                    SpName.OrderInsert,
                    new
                    {
                        StoreId = order.Store.Id,
                        ProductId = order.Product.Id,
                        order.Quantity,
                        order.OrderAddress,
                        order.CurrencyExchangeRate
                    },
                    transaction: transaction,
                    commandType: CommandType.StoredProcedure);
                order.Id = (int)result.FirstOrDefault();

                return await OrderGetById((int)order.Id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void TransactionStart()
        {
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        public void TransactionCommit()
        {
            transaction?.Commit();
            connection?.Close();
        }

        public void TransactioRollBack()
        {
            transaction?.Rollback();
            connection?.Close();
        }
    }

}
