using Store.DB.Models;
using System.Threading.Tasks;

namespace Store.Repository
{
    public interface IProductRepository
    {
        ValueTask<RequestResult<Product>> GetProductById(int productId);
    }
}