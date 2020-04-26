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

        }

        public async ValueTask<Product> GetProductById(int id)
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

        public void Transactionstart(IDbTransaction dbTransaction)
        {
            _dbTransaction = dbTransaction;
        }
    }
}
