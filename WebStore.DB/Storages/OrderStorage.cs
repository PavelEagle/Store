using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Core.ConfigurationOptions;
using WebStore.DB.Models;

namespace WebStore.DB.Storages
{
    public class OrderStorage : BaseStorage, IOrderStorage
    {
        public OrderStorage(IOptions<StorageOptions> storageOptions) : base(storageOptions)
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
                var orderDictionary = new Dictionary<int, OrderInfo>();

                var result = await connection.QueryAsync<OrderInfo, City, Store, Product_Order, OrderInfo>(
                    SpName.OrderGetById,
                    (orderInfo, city, store, po) =>
                    {
                        if (!orderDictionary.TryGetValue((int)orderInfo.OrderId, out OrderInfo newOrderInfo))
                        {
                            newOrderInfo = orderInfo;
                            newOrderInfo.Store = store;
                            newOrderInfo.Store.City = city;
                            newOrderInfo.Products = new List<Product_Order>();
                            orderDictionary.Add((int)orderInfo.OrderId, newOrderInfo);
                        }

                        if (po != null)
                        {
                            newOrderInfo.Products.Add(po);
                        }

                        return newOrderInfo;
                    },
                    new
                    {
                        orderId
                    },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");;
                return result.Distinct().ToList().FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<OrderInfo> OrderInser(OrderInfo order)
        {
            return new OrderInfo();
            //    try
            //    {
            //        var result = await connection.QueryAsync<long>(
            //            SpName.OrderInsert,
            //            new
            //            {
            //                StoreId = order.Store.Id,
            //                //ProductId = order.Product.Id,
            //                //order.Quantity,
            //                //order.OrderAddress,
            //                //order.CurrencyExchangeRate
            //            },
            //            transaction: transaction,
            //            commandType: CommandType.StoredProcedure);
            //        order.Id = (int)result.FirstOrDefault();

            //        return await OrderGetById((int)order.Id);
            //    }
            //    catch (SqlException ex)
            //    {
            //        throw ex;
            //    }
        }
    }
}
