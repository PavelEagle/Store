namespace WebStore.DB.Storages
{
    public interface IBaseStorage
    {
        void TransactionCommit();
        void TransactionStart();
        void TransactioRollBack();
    }
}