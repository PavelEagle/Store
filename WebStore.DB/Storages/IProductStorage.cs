using WebStore.DB.Models;
using System.Threading.Tasks;
using System.Data;

namespace WebStore.DB.Storages
{
    public interface IProductStorage : IBaseStorage
    {
        ValueTask<Product> ProductGetById(int id);
        ValueTask<Product> ProductInsertOrUpdate(Product product);
        ValueTask ProductDeleteById(int id);
    }
}