using Microsoft.AspNetCore.Mvc;
using Store.API.Models.InputModels;
using Store.DB.Models;
using Store.DB.Storages;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase, IStoreController
    {
        private readonly IStoreStorage _storeStorage;

        public StoreController(IStoreStorage storeStorage)
        {
            _storeStorage = storeStorage;
        }
        //[HttpPost("city")]
        //public async ValueTask<ActionResult<City>> CityInsert(CityInputModel leadInputModel)
        //{
        //    if (leadInputModel.Id < 1) return BadRequest("LeadId can not be less than one.");
        //    var result = await _storeStorage.CityInsert(CityMapper.ToDataModel(leadInputModel));
        //    return Ok(CityMapper.ToOutputModel(result));
        //}
    }
}