using Dapper;
using WebStore.DB.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Globalization;
using WebStore.Core.ConfigurationOptions;
using Microsoft.Extensions.Options;

namespace  WebStore.DB.Storages
{
    public class ReportStorage: BaseStorage, IReportStorage
    {
        public ReportStorage(IOptions<StorageOptions> storageOptions) : base (storageOptions)
        {
            connection = new SqlConnection(storageOptions.Value.DBConnectionString);
        }

        internal static class SpName
        {
            public const string GetMoneyInEachCity = "Report_GetMoneyInEachCity";
            public const string GetBestSellingProducts = "Report_GetBestSellingProducts";
            public const string GetProductsInWarehouseAndAbsentInMskAndSpb = "Report_GetProductsInWarehouseAndAbsentInMskAndSpb";
            public const string GetCategoryWithFiveAndMoreProducts = "Report_GetCategoryWithFiveAndMoreProducts";
            public const string GetInfoAboutOrdersByDate = "Report_GetInfoAboutOrdersByDate";
            public const string GetNoOrderedProducts = "Report_GetNoOrderedProducts";
            public const string GetSalesByWorldAndRF = "Report_GetSalesByWorldAndRF";
            public const string GetSoldOutProduct = "Report_GetSoldOutProduct";
        }

        public async ValueTask<List<City>> GetMoneyInEachCity()
        {
            var result = await connection.QueryAsync<City>(
                SpName.GetMoneyInEachCity,
                null,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async ValueTask<List<ProductInStore>> GetBestSellingProducts()
        {
            var result = await connection.QueryAsync<City, Store, ProductInStore, ProductInStore>(
            SpName.GetBestSellingProducts,
            (city, store, bsproduct) =>
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

        public async ValueTask<List<OrderInfo>> GetInfoAboutOrdersByDate(DateModel dateModel)
        {
            var orderDictionary = new Dictionary<int, OrderInfo>();

            var result = await connection.QueryAsync<OrderInfo, City, Store, Product_Order, OrderInfo>(
                SpName.GetInfoAboutOrdersByDate,
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
                    dateModel.startDate,
                    dateModel.endDate
                },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id");
            return result.Distinct().ToList();
        }

        public async ValueTask<List<ProductInStore>> GetProductsInWarehouseAndAbsentInMskAndSpb()
        {
            var result = await connection.QueryAsync<ProductInStore, City, Store, ProductInStore>(
                SpName.GetProductsInWarehouseAndAbsentInMskAndSpb,
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

        public async ValueTask<List<Category>> GetCategoryWithFiveAndMoreProducts()
        {
            var result = await connection.QueryAsync<Category>(
                SpName.GetCategoryWithFiveAndMoreProducts,
                null,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async ValueTask<List<Product>> GetNoOrderedProducts()
        {
            var result = await connection.QueryAsync<Product>(
                SpName.GetNoOrderedProducts,
                null,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async ValueTask<List<Product>> GetSoldOutProduct()
        {
            var result = await connection.QueryAsync<Product>(
                SpName.GetSoldOutProduct,
                null,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async ValueTask<SalesByWorldAndRF> GetSalesByWorldAndRF()
        {
            var result = await connection.QueryAsync<SalesByWorldAndRF>(
                SpName.GetSalesByWorldAndRF,
                null,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
