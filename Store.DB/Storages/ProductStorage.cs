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
    public class ProductStorage
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction dbTransaction;
        private string connStr = "Data Source=DESKTOP-C936NF2\\SQLEXPRESS;Initial Catalog=Store;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public ProductStorage(IOptions<StorageOptions> storageOptions)
        {
            this.connection = new SqlConnection(storageOptions.Value.DBConnectionString);
        }
        public ProductStorage()
        {
            connection = new SqlConnection(connStr);
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
                    //dbTransaction,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id,Id");
                return result.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
