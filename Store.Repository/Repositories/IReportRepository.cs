using Store.DB.Models;
using Store.DB.Models.Reports;
using Store.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store
{
    public interface IReportRepository
    {
        ValueTask<RequestResult<List<BestSellerProduct>>> GetBestSellingProduct();
        ValueTask<RequestResult<List<MoneyInCity>>> GetMoneyInEachCity();
    }
}