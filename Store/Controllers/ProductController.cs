using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Models.Mapping;
using Store.DB.Models;
using Store.DB.Storages;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductStorage productStorage;
        public ProductController()
        {
            productStorage = new ProductStorage();
        }
        [HttpGet("{productId}")]
        public async ValueTask<ActionResult<Product>> GetProductById(int productId)
        {
            if (productId < 1) return BadRequest("LeadId can not be less than one.");
            var result = await productStorage.GetProductById(productId);
            return Ok(ProductMapper.ToOutputModel(result));
        }
    }
}