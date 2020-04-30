using Dapper;
using Microsoft.Extensions.Options;
using WebStore.Core.ConfigurationOptions;
using WebStore.DB.Models;
using WebStore.DB.Models.Reports;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace  WebStore.DB.Storages
{
    public class ReportStorage : IReportStorage
    {
        private readonly IDbConnection connection;

        public ReportStorage(IOptions<StorageOptions> storageOptions)
        {
            connection = new SqlConnection(storageOptions.Value.DBConnectionString);
        }

        internal static class SpName
        {
            public const string GetMoneyInEachCity = "Report_GetMoneyInEachCity";
            public const string GetBestSellingProduct = "Report_GetBestSellingProduct";
            public const string GetProductsInWarehouseAndAbsentInMoscowAndSpb = "Report_GetProductsInWarehouseAndAbsentInMoscowAndSpb";
            public const string GetCategoryWithFiveAndMoreProduct = "Report_GetCategoryWithFiveAndMoreProduct";
            public const string GetInfoAboutOrdersByDate = "Report_GetInfoAboutOrdersByDate";
            public const string GetNoOrderedProducts = "Report_GetNoOrderedProducts";
            public const string GetSalesAmountInsideAndOutsideRF = "Report_GetSalesAmountInsideAndOutsideRF";
            public const string GetSoldOutProduct = "Report_GetSoldOutProduct";
        }

        public async ValueTask<List<MoneyInCity>> GetMoneyInEachCity()
        {
            try
            {
                var result = await connection.QueryAsync<MoneyInCity>(
                    SpName.GetMoneyInEachCity,
                    null,
                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<ProductInStore>> GetBestSellingProduct()
        {
            try
            {
                var result = await connection.QueryAsync<ProductInStore, Models.Store, ProductInStore>(
                    SpName.GetBestSellingProduct,
                    (bsproduct, store) =>
                    {
                        ProductInStore newProduct = bsproduct;
                        newProduct.Store = store;
                        return newProduct;
                    },
                    null,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<OrderInfo>> GetInfoAboutOrdersByDate(DateOrder date)
        {
            try
            {
                var result = await connection.QueryAsync<City, Store, Product, OrderInfo, OrderInfo>(
                    SpName.GetInfoAboutOrdersByDate,
                    (city, store, product, orderinfo) =>
                    {
                        OrderInfo newOrderInfo = orderinfo;
                        orderinfo.Store = store;
                        store.City = city;
                        newOrderInfo.Product = product;
                        return newOrderInfo;
                    },
                    new { date.StartDate, date.EndDate },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<ProductInStore>> GetProductsInWarehouseAndAbsentInMoscowAndSpb()
        {
            try
            {
                var result = await connection.QueryAsync<ProductInStore, City, Store, ProductInStore>(
                    SpName.GetProductsInWarehouseAndAbsentInMoscowAndSpb,
                    (bsproduct, city, store) =>
                    {
                        ProductInStore newProduct = bsproduct;
                        newProduct.Store = store;
                        store.City = city;
                        return newProduct;
                    },
                    null,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<CountProductInCategory>> GetCategoryWithFiveAndMoreProduct()
        {
            try
            {
                var result = await connection.QueryAsync<CountProductInCategory>(
                    SpName.GetCategoryWithFiveAndMoreProduct,
                    null,
                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<Product>> GetNoOrderedProducts()
        {
            try
            {
                var result = await connection.QueryAsync<Product>(
                    SpName.GetNoOrderedProducts,
                    null,
                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<Product>> GetSoldOutProduct()
        {
            try
            {
                var result = await connection.QueryAsync<Product>(
                    SpName.GetSoldOutProduct,
                    null,
                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


    }
}
