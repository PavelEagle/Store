using Dapper;
using Microsoft.Extensions.Options;
using WebStore.Core.ConfigurationOptions;
using WebStore.DB.Models;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.DB.Storages
{
    public class ProductStorage : BaseStorage, IProductStorage
    {
        public ProductStorage(IOptions<StorageOptions> storageOptions) : base(storageOptions)
        {
            connection = new SqlConnection(storageOptions.Value.DBConnectionString);
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

        public async ValueTask<Product> ProductInsertOrUpdate(Product product)
        {
            try
            {
                DynamicParameters ProductParams = new DynamicParameters(new
                {
                    product.Id,
                    product.Manufacturer,
                    product.Model,
                    product.Price,
                    subcategoryId = product.Subcategory.Id
                });

                if (product.Id == null)
                {
                    var result = await connection.QueryAsync<long>(
                        SpName.ProductInsertOrUpdate,
                        ProductParams,
                        transaction: transaction,
                        commandType: CommandType.StoredProcedure);
                    product.Id = (int)result.FirstOrDefault();
                }
                else
                {
                    await connection.QueryAsync(
                        SpName.ProductInsertOrUpdate,
                        ProductParams,
                        commandType: CommandType.StoredProcedure);
                }

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
                    transaction: transaction,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
