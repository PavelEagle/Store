using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebStore.API.Models.InputModels;
using WebStore.Core.Common;

namespace WebStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        [HttpPost("pagination")]
        public async ValueTask<ActionResult<Pagination>> InsertOrUpdateProduct(PageInfo pageInfoInputModel)
        {
            if (pageInfoInputModel.TotalItems>0)
            {
                var result = new Pagination(pageInfoInputModel.TotalItems, pageInfoInputModel.CurrentPage, pageInfoInputModel.PageSize, pageInfoInputModel.MaxPages);
                return Ok(JsonConvert.SerializeObject(result));
            }
            else
            {
                return BadRequest("Enter currect productId");
            }
        }
    }
}

