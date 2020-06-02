using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.API.Models.InputModels;
using WebStore.API.Models.OutputModels;
using WebStore.DB.Models;
using WebStore.Repository.Repositories;

namespace WebStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
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
            if (productId < 1) return BadRequest("Enter currect productId");
            var result = await _productRepository.ProductGetById(productId);
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return NotFound("Product not found"); }
                return Ok(_mapper.Map<ProductOutputModel>(result.RequestData));
            }
            return Problem($"Something went wrong: {result.ExMessage}", statusCode: 520);

        }

        [HttpPost]
        public async ValueTask<ActionResult<ProductOutputModel>> InsertOrUpdateProduct(ProductInputModel productInputModel)
        {
            if (productInputModel.Id < 1) return BadRequest("Enter currect productId");
            var result = await _productRepository.ProductInsertOrUpdate(_mapper.Map<Product>(productInputModel));
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<ProductOutputModel>(result.RequestData));
            }
            return Problem($"Something went wrong: {result.ExMessage}", statusCode: 520);
        }

        [HttpDelete("{productId}")]
        public async ValueTask<ActionResult<string>> DeleteProduct(int productId)
        {
            if (productId < 1) return BadRequest("Enter currect productId");
            var result = await _productRepository.ProductDelete(productId);
            if (result.IsOkay) 
            {
                return Ok(result.RequestData); 
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);

        }
    }
}