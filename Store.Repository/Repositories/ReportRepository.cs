using Store.DB.Models;
using Store.DB.Storages;
using Store.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store
{
    public class ReportRepository : IReportRepository
    {
        private readonly IReportStorage _productStorage;

        public ReportRepository(IReportStorage reportStorage)
        {
            _productStorage = reportStorage;
        }

        public async ValueTask<RequestResult<List<MoneyInCity>>> ProductGetById()
        {
            var result = new RequestResult<List<MoneyInCity>>();
            try
            {
                result.RequestData = await _productStorage.GetMoneyInEachCity();
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
