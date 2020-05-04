using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using WebStore.Core.ConfigurationOptions;

namespace WebStore.DB.Storages
{
    public class BaseStorage : IBaseStorage
    {
        public IDbTransaction transaction;
        public IDbConnection connection;

        public BaseStorage(IOptions<StorageOptions> storageOptions)
        {
            connection = new SqlConnection(storageOptions.Value.DBConnectionString);
        }
        public void TransactionStart()
        {
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        public void TransactionCommit()
        {
            transaction?.Commit();
            connection?.Close();
        }

        public void TransactioRollBack()
        {
            transaction?.Rollback();
            connection?.Close();
        }
    }
}
