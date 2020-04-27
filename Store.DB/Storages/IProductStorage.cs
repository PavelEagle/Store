using Store.DB.Models;
using System.Data;
using System.Threading.Tasks;

namespace Store.DB.Storages
{
    public interface IProductStorage
    {
        ValueTask<Product> ProductGetById(int id);
        ValueTask<Product> ProductInsertOrUpdate(Product product);
        ValueTask ProductDeleteById(int id);
        void Transactionstart(IDbTransaction dbTransaction);
    }
}