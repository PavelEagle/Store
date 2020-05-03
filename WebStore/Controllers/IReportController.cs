using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.API.Models.OutputModels;

namespace WebStore.API.Controllers
{
    public interface IReportController
    {
        ValueTask<ActionResult<ProductInStoreOutputModel>> GetBestSellingProducts();
        ValueTask<ActionResult<CountProductInCategoryOutputModel>> GetCategoryWithFiveAndMoreProducts();
        ValueTask<ActionResult<OrderInfoOutputModel>> GetInfoAboutOrdersByDate(string startDate, string EndDate);
        ValueTask<ActionResult<List<MoneyInCityOutputModel>>> GetMoneyInEachCity();
        ValueTask<ActionResult<ShortProductOutputModel>> GetNoOrderedProducts();
        ValueTask<ActionResult<List<ProductInStoreOutputModel>>> GetProductsInWarehouseAndAbsentInMskAndSpb();
        ValueTask<ActionResult<SalesByWorldAndRFOutputModel>> GetSalesByWorldAndRF();
        ValueTask<ActionResult<ShortProductOutputModel>> GetSoldOutProduct();
    }
}