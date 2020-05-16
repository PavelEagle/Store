using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebStore.API.Models.OutputModels;

namespace WebStore.API.Controllers
{
    public interface IOrderController
    {
        ValueTask<ActionResult<OrderInfoOutputModel>> GetOrderById(int orderId);
    }
}