using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.API.Models.OutputModels;
using WebStore.Repository.Repositories;

namespace WebStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        public OrderController(IMapper mapper, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        [HttpGet("{orderId}")]
        public async ValueTask<ActionResult<OrderInfoOutputModel>> GetOrderById(int orderId)
        {
            if (orderId < 1) return BadRequest("Enter currect orderId");
            var result = await _orderRepository.OrderGetById(orderId);
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return NotFound("Product not found"); }
                return Ok(_mapper.Map<OrderInfoOutputModel>(result.RequestData));
            }
            return Problem($"Something went wrong: {result.ExMessage}", statusCode: 520);

        }
    }
}