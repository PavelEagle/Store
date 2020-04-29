using Dapper;
using Microsoft.Extensions.Options;
using Store.Core.ConfigurationOptions;
using Store.DB.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace  Store.DB.Storages
{
    public class ReportStorage : IReportStorage
    {
        private readonly IDbConnection connection;

        public ReportStorage(IOptions<StorageOptions> storageOptions)
        {
            this.connection = new SqlConnection(storageOptions.Value.DBConnectionString);
        }

        internal static class SpName
        {
            public const string GetMoneyInEachCity = "Report_GetMoneyInEachCity";
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
    }
}
