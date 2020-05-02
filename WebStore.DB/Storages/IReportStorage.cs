using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.DB.Models;
using WebStore.DB.Models.Reports;

namespace WebStore.DB.Storages
{
    public interface IReportStorage
    {
        ValueTask<List<ProductInStore>> GetBestSellingProduct();
        ValueTask<List<CountProductInCategory>> GetCategoryWithFiveAndMoreProduct();
        ValueTask<List<OrderInfo>> GetInfoAboutOrdersByDate(string startDate, string endDate);
        ValueTask<List<MoneyInCity>> GetMoneyInEachCity();
        ValueTask<List<Product>> GetNoOrderedProducts();
        ValueTask<List<ProductInStore>> GetProductsInWarehouseAndAbsentInMoscowAndSpb();
        ValueTask<List<Product>> GetSoldOutProduct();
    }
}