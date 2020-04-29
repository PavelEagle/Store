using Microsoft.AspNetCore.Mvc;
using Store.API.Models.OutputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    public interface IReportController
    {
        ValueTask<ActionResult<BestSellerProductOutputModel>> GetBestSellingProduct();
        ValueTask<ActionResult<object>> GetCategoryWithFiveAndMoreProduct();
        ValueTask<ActionResult<object>> GetInfoAboutOrdersByDate();
        ValueTask<ActionResult<List<MoneyInCityOutputModel>>> GetMoneyInEachCity();
        ValueTask<ActionResult<object>> GetNoOrderedProducts();
        ValueTask<ActionResult<object>> GetProductsInWarehouseAndAbsentInMoscowAndSpb();
        ValueTask<ActionResult<object>> GetSalesAmountInsideAndOutsideRF();
        ValueTask<ActionResult<object>> GetSoldOutProduct();
    }
}