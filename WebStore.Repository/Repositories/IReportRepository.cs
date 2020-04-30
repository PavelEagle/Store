using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.DB.Models;
using WebStore.DB.Models.Reports;
using WebStore.Repository;

namespace WebStore
{
    public interface IReportRepository
    {
        ValueTask<RequestResult<List<ProductInStore>>> GetBestSellingProduct();
        ValueTask<RequestResult<List<CountProductInCategory>>> GetCategoryWithFiveAndMoreProduct();
        ValueTask<RequestResult<List<OrderInfo>>> GetInfoAboutOrdersByDate(DateOrder date);
        ValueTask<RequestResult<List<MoneyInCity>>> GetMoneyInEachCity();
        ValueTask<RequestResult<List<Product>>> GetNoOrderedProducts();
        ValueTask<RequestResult<List<ProductInStore>>> GetProductsInWarehouseAndAbsentInMoscowAndSpb();
        ValueTask<RequestResult<List<Product>>> GetSoldOutProduct();
    }
}