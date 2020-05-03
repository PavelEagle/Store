using System.Threading.Tasks;
using WebStore.DB.Models;

namespace WebStore.Repository.Repositories
{
    public interface IOrderRepository
    {
        ValueTask<RequestResult<OrderInfo>> OrderGetById(int productId);
    }
}