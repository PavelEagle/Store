using WebStore.DB.Models;
using System.Threading.Tasks;

namespace WebStore.Repository
{
    public interface IProductRepository
    {
        ValueTask<RequestResult<string>> ProductDelete(int id);
        ValueTask<RequestResult<Product>> ProductGetById(int productId);
        ValueTask<RequestResult<Product>> ProductInsertOrUpdate(Product dataModel);
    }
}