using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.API.Models.OutputModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Repository.Repositories;

namespace WebStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase, IReportController
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;
        public ReportController(IMapper mapper, IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        [HttpGet("money-in-city")]
        public async ValueTask<ActionResult<List<MoneyInCityOutputModel>>> GetMoneyInEachCity()
        {
            var result = await _reportRepository.GetMoneyInEachCity();
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<List<MoneyInCityOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("info-about-orders-by-date/{startDate}/{EndDate}")]
        public async ValueTask<ActionResult<List<List<OrderInfoOutputModel>>>> GetInfoAboutOrdersByDate(string startDate, string EndDate)
        {
            var result = await _reportRepository.GetInfoAboutOrdersByDate(startDate, EndDate);
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<List<OrderInfoOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("best-selling-products")]
        public async ValueTask<ActionResult<ProductInStoreOutputModel>> GetBestSellingProducts()
        {
            var result = await _reportRepository.GetBestSellingProducts();
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<List<ProductInStoreOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("products-in-warehouse-and-absent-in-msk-and-spb")]
        public async ValueTask<ActionResult<List<ProductInStoreOutputModel>>> GetProductsInWarehouseAndAbsentInMskAndSpb()
        {
            var result = await _reportRepository.GetProductsInWarehouseAndAbsentInMskAndSpb();
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<List<ProductInStoreOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("category-with-five-and-more-products")]
        public async ValueTask<ActionResult<CountProductInCategoryOutputModel>> GetCategoryWithFiveAndMoreProducts()
        {
            var result = await _reportRepository.GetCategoryWithFiveAndMoreProducts();
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<List<CountProductInCategoryOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("sold-out-products")]
        public async ValueTask<ActionResult<ShortProductOutputModel>> GetSoldOutProduct()
        {
            var result = await _reportRepository.GetSoldOutProduct();
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<List<ShortProductOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("no-ordered-products")]
        public async ValueTask<ActionResult<ShortProductOutputModel>> GetNoOrderedProducts()
        {
            var result = await _reportRepository.GetNoOrderedProducts();
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<List<ShortProductOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("sales-by-world-and-rf")]
        public async ValueTask<ActionResult<SalesByWorldAndRFOutputModel>> GetSalesByWorldAndRF()
        {
            var result = await _reportRepository.GetSalesByWorldAndRF();
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<SalesByWorldAndRFOutputModel>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

    }
}