using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Store.DB.Storages
{
    public class Transaction
    {
        public IDbTransaction _dbTransaction;
        public void TransactionStart(IDbConnection connection)
        {
            connection.Open();
            _dbTransaction = connection.BeginTransaction();
        }

        public void TransactionCommit(IDbConnection connection, IDbTransaction transaction)
        {
            _dbTransaction?.Commit();
            connection?.Close();
        }

        public void TransactioRollBack(IDbConnection connection, IDbTransaction transaction)
        {
            _dbTransaction?.Rollback();
            connection?.Close();
        }
    }
}
