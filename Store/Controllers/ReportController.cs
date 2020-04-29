using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.API.Models.OutputModels;
using Store.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
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
            var result = await _reportRepository.ProductGetById();
            if (result.IsOkay)
            {
                return Ok(_mapper.Map<List<MoneyInCityOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("info-about-orders-by-date")]
        public async ValueTask<ActionResult<object>> GetInfoAboutOrdersByDate()
        {
            return new object();
        }

        [HttpGet("best-selling-product")]
        public async ValueTask<ActionResult<object>> GetBestSellingProduct()
        {
            return new object();
        }

        [HttpGet("products-in-warehouse-and-absent-in-moscow-and-spb")]
        public async ValueTask<ActionResult<object>> GetProductsInWarehouseAndAbsentInMoscowAndSpb()
        {
            return new object();
        }

        [HttpGet("category-with-five-and-more-product")]
        public async ValueTask<ActionResult<object>> GetCategoryWithFiveAndMoreProduct()
        {
            return new object();
        }

        [HttpGet("sold-out-product")]
        public async ValueTask<ActionResult<object>> GetSoldOutProduct()
        {
            return new object();
        }

        [HttpGet("no-ordered-products")]
        public async ValueTask<ActionResult<object>> GetNoOrderedProducts()
        {
            return new object();
        }

        [HttpGet("sales-amount-inside-and-outside-rf")]
        public async ValueTask<ActionResult<object>> GetSalesAmountInsideAndOutsideRF()
        {
            return new object();
        }

    }
}