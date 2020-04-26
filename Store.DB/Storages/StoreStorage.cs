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
    public class StoreStorage : IStoreStorage
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction dbTransaction;
        public StoreStorage(IOptions<StorageOptions> storageOptions)
        {
            this.connection = new SqlConnection(storageOptions.Value.DBConnectionString);
        }

        internal static class SpName
        {
            public const string CityInsert = "City_Insert";
        }

        public async ValueTask<City> CityInsert(City model)
        {
            try
            {
                var result = await connection.QueryAsync<City>(
                    SpName.CityInsert,
                    new
                    {
                        model.Name,
                        model.RU
                    },
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }

}
