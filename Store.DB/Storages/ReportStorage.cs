using Dapper;
using Microsoft.Extensions.Options;
using Store.Core.ConfigurationOptions;
using Store.DB.Models;
using Store.DB.Models.Reports;
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
            connection = new SqlConnection(storageOptions.Value.DBConnectionString);
        }

        internal static class SpName
        {
            public const string GetMoneyInEachCity = "Report_GetMoneyInEachCity";
            public const string GetBestSellingProduct = "Report_GetBestSellingProduct";

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

        public async ValueTask<List<BestSellerProduct>> GetBestSellingProduct()
        {
            try
            {
                var result = await connection.QueryAsync<BestSellerProduct>(
                    SpName.GetBestSellingProduct,
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
