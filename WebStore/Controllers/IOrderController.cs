using Microsoft.AspNetCore.Mvc;
using WebStore.DB.Models;
using System.Threading.Tasks;

namespace WebStore.API.Controllers
{
    public interface IOrderController
    {
        ValueTask<ActionResult<Order>> AddOrder(object leadInputModel);
        ValueTask<ActionResult<Order>> GetOrderById(int orderId);
    }
}