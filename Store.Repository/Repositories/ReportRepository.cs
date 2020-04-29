using Store.DB.Models;
using Store.DB.Models.Reports;
using Store.DB.Storages;
using Store.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store
{
    public class ReportRepository : IReportRepository
    {
        private readonly IReportStorage _reportStorage;

        public ReportRepository(IReportStorage reportStorage)
        {
            _reportStorage = reportStorage;
        }

        public async ValueTask<RequestResult<List<MoneyInCity>>> GetMoneyInEachCity()
        {
            var result = new RequestResult<List<MoneyInCity>>();
            try
            {
                result.RequestData = await _reportStorage.GetMoneyInEachCity();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<BestSellerProduct>>> GetBestSellingProduct()
        {
            var result = new RequestResult<List<BestSellerProduct>>();
            try
            {
                result.RequestData = await _reportStorage.GetBestSellingProduct();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }
    }
}
