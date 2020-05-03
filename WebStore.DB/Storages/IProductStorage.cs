using WebStore.DB.Models;
using System.Threading.Tasks;

namespace WebStore.DB.Storages
{
    public interface IProductStorage
    {
        ValueTask<Product> ProductGetById(int id);
        ValueTask<Product> ProductInsertOrUpdate(Product product);
        ValueTask ProductDeleteById(int id);
        void TransactionStart();
        void TransactionCommit();
        void TransactioRollBack();
    }
}