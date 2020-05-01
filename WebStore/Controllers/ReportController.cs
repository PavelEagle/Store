using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.API.Models.OutputModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.API.Models.InputModels;
using WebStore.DB.Models.Reports;

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

        [HttpGet("info-about-orders-by-date")]
        public async ValueTask<ActionResult<OrderInfoOutputModel>> GetInfoAboutOrdersByDate(DateOrderInputModel model)
        {
            var result = await _reportRepository.GetInfoAboutOrdersByDate(_mapper.Map<DateOrder>(model));
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<List<OrderInfoOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("best-selling-product")]
        public async ValueTask<ActionResult<ProductInStoreOutputModel>> GetBestSellingProduct()
        {
            var result = await _reportRepository.GetBestSellingProduct();
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<List<ProductInStoreOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("products-in-warehouse-and-absent-in-moscow-and-spb")]
        public async ValueTask<ActionResult<List<ProductInStoreOutputModel>>> GetProductsInWarehouseAndAbsentInMoscowAndSpb()
        {
            var result = await _reportRepository.GetProductsInWarehouseAndAbsentInMoscowAndSpb();
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<List<ProductInStoreOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("category-with-five-and-more-product")]
        public async ValueTask<ActionResult<CountProductInCategoryOutputModel>> GetCategoryWithFiveAndMoreProduct()
        {
            var result = await _reportRepository.GetCategoryWithFiveAndMoreProduct();
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<List<CountProductInCategoryOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("sold-out-product")]
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

        [HttpGet("sales-amount-inside-and-outside-rf")]
        public async ValueTask<ActionResult<object>> GetSalesAmountInsideAndOutsideRF()
        {
            return new object();
        }

    }
}