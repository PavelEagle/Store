using Microsoft.AspNetCore.Mvc;
using Store.API.Models.InputModels;
using Store.API.Models.Mapping;
using Store.DB.Models;
using Store.DB.Storages;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        StoreStorage storeStorage;

        public StoreController()
        {
            storeStorage = new StoreStorage();
        }
        [HttpPost("city")]
        public async ValueTask<ActionResult<City>> CityInsert(CityInputModel leadInputModel)
        {
            if (leadInputModel.Id < 1) return BadRequest("LeadId can not be less than one.");
            var result = await storeStorage.CityInsert(CityMapper.ToDataModel(leadInputModel));
            return Ok(CityMapper.ToOutputModel(result));
        }
    }
}