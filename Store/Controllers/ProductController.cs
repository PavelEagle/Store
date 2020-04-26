using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.API.Models.Mapping;
using Store.API.Models.OutputModels;
using Store.DB.Models;
using Store.DB.Storages;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductController
    {

        private readonly IMapper _mapper;
        private readonly IProductStorage _productStorage;
        public ProductController(IMapper mapper, IProductStorage productStorage)
        {
            _productStorage = productStorage;
            _mapper = mapper;
        }
        [HttpGet("{productId}")]
        public async ValueTask<ActionResult<ProductOutputModel>> GetProductById(int productId)
        {
            if (productId < 1) return BadRequest("LeadId can not be less than one.");
            var result = await _productStorage.GetProductById(productId);
            return Ok(_mapper.Map<ProductOutputModel>(result));
            //return Ok(ProductMapper.ToOutputModel(result));
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