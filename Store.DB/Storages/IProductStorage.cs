using Store.DB.Models;
using System.Threading.Tasks;

namespace Store.DB.Storages
{
    public interface IProductStorage
    {
        ValueTask<Product> GetProductById(int id);
    }
}