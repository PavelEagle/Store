using Dapper;
using Microsoft.Extensions.Options;
using Store.Core.ConfigurationOptions;
using Store.DB.Models;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DB.Storages
{
    public class ProductStorage : Transaction, IProductStorage
    {
        private readonly IDbConnection connection;

        public ProductStorage(IOptions<StorageOptions> storageOptions)
        {
            this.connection = new SqlConnection(storageOptions.Value.DBConnectionString);
        }

        internal static class SpName
        {
            public const string ProductGetById = "Product_GetById";
            public const string ProductDeleteById = "Product_DeleteById";
            public const string ProductInsertOrUpdate = "Product_InsertOrUpdate";

        }

        public async ValueTask<Product> ProductGetById(int id)
        {
            try
            {
                var result = await connection.QueryAsync<Product, Subcategory, Category, Product>(
                    SpName.ProductGetById,
                    (product, subcategory, category) =>
                    {
                        Subcategory sabcat = subcategory;
                        sabcat.Category = category;

                        Product newProd = product;
                        newProd.Subcategory = sabcat;
                        return newProd;
                    },
                    param: new { id },
                    _dbTransaction,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");
                return result.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<Product> ProductInsertOrUpdate(Product product)
        {
            try
            {
                DynamicParameters leadModelParams = new DynamicParameters(new
                {
                    product.Id,
                    product.Manufacturer,
                    product.Model,
                    product.Price,
                    product.Subcategory
                });
                var result = await connection.QueryAsync<long>(
                    SpName.ProductInsertOrUpdate,
                    leadModelParams,
                    commandType: CommandType.StoredProcedure);
                product.Id = (int)result.FirstOrDefault();
                return await ProductGetById((int)product.Id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public async ValueTask ProductDeleteById(int id)
        {
            try
            {
                await connection.QueryAsync<long>(
                    SpName.ProductDeleteById,
                    new { id },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }




        public void Transactionstart(IDbTransaction dbTransaction)
        {
            _dbTransaction = dbTransaction;
        }
    }
}
