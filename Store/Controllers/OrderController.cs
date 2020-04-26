using Microsoft.AspNetCore.Mvc;
using Store.DB.Models;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
        [HttpPost]
        public async ValueTask<ActionResult<Order>> AddOrder(object leadInputModel)
        {
            return Ok(new Order { });
        }

        [HttpGet("{orderId}")]
        public async ValueTask<ActionResult<Order>> GetOrderById(int orderId)
        {
            return Ok(new Order { });
        }

    }
}