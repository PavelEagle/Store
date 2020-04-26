using Microsoft.AspNetCore.Mvc;
using Store.DB.Models;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    public interface IOrderController
    {
        ValueTask<ActionResult<Order>> AddOrder(object leadInputModel);
        ValueTask<ActionResult<Order>> GetOrderById(int orderId);
    }
}