using WebStore.DB.Models;
using System.Threading.Tasks;
using WebStore.Core;

namespace WebStore.Repository.Repositories
{
    public interface IProductRepository
    {
        ValueTask<RequestResult<string>> ProductDelete(int id);
        ValueTask<RequestResult<Product>> ProductGetById(int productId);
        ValueTask<RequestResult<Product>> ProductInsertOrUpdate(Product dataModel);
    }
}