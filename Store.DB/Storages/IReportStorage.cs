using Store.DB.Models;
using Store.DB.Models.Reports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DB.Storages
{
    public interface IReportStorage
    {
        ValueTask<List<BestSellerProduct>> GetBestSellingProduct();
        ValueTask<List<MoneyInCity>> GetMoneyInEachCity();
    }
}