using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.API.Models.OutputModels;
using Store.DB.Models;
using Store.Repository;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductController
    {
        
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductController(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet("{productId}")]
        public async ValueTask<ActionResult<ProductOutputModel>> GetProductById(int productId)
        {
            if (productId < 1) return BadRequest("LeadId can not be less than one.");
            var result = await _productRepository.GetProductById(productId);
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return NotFound("Lead not found"); }
                return Ok(_mapper.Map<ProductOutputModel>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);

        }

        [HttpPost]
        public async ValueTask<ActionResult<Product>> InsertOrUpdateProduct(object leadInputModel)
        {
            return Ok(new Product { });
        }

        [HttpDelete("{orderId}")]
        public async ValueTask<ActionResult<Order>> DeleteProduct(int productId)
        {
            return Ok(new Order { });
        }
    }
}