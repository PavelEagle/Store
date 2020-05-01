using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.API.Models.InputModels;
using WebStore.API.Models.OutputModels;

namespace WebStore.API.Controllers
{
    public interface IReportController
    {
        ValueTask<ActionResult<ProductInStoreOutputModel>> GetBestSellingProduct();
        ValueTask<ActionResult<CountProductInCategoryOutputModel>> GetCategoryWithFiveAndMoreProduct();
        ValueTask<ActionResult<OrderInfoOutputModel>> GetInfoAboutOrdersByDate(DateOrderInputModel model);
        ValueTask<ActionResult<List<MoneyInCityOutputModel>>> GetMoneyInEachCity();
        ValueTask<ActionResult<ShortProductOutputModel>> GetNoOrderedProducts();
        ValueTask<ActionResult<List<ProductInStoreOutputModel>>> GetProductsInWarehouseAndAbsentInMoscowAndSpb();
        ValueTask<ActionResult<object>> GetSalesAmountInsideAndOutsideRF();
        ValueTask<ActionResult<ShortProductOutputModel>> GetSoldOutProduct();
    }
}