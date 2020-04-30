using WebStore.DB.Models;
using WebStore.DB.Models.Reports;
using WebStore.DB.Storages;
using WebStore.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebStore
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

        public async ValueTask<RequestResult<List<ProductInStore>>> GetBestSellingProduct()
        {
            var result = new RequestResult<List<ProductInStore>>();
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

        public async ValueTask<RequestResult<List<ProductInStore>>> GetProductsInWarehouseAndAbsentInMoscowAndSpb()
        {
            var result = new RequestResult<List<ProductInStore>>();
            try
            {
                result.RequestData = await _reportStorage.GetProductsInWarehouseAndAbsentInMoscowAndSpb();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<CountProductInCategory>>> GetCategoryWithFiveAndMoreProduct()
        {
            var result = new RequestResult<List<CountProductInCategory>>();
            try
            {
                result.RequestData = await _reportStorage.GetCategoryWithFiveAndMoreProduct();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<OrderInfo>>> GetInfoAboutOrdersByDate(DateOrder date)
        {
            var result = new RequestResult<List<OrderInfo>>();
            try
            {
                result.RequestData = await _reportStorage.GetInfoAboutOrdersByDate(date);
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Product>>> GetNoOrderedProducts()
        {
            var result = new RequestResult<List<Product>>();
            try
            {
                result.RequestData = await _reportStorage.GetNoOrderedProducts();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Product>>> GetSoldOutProduct()
        {
            var result = new RequestResult<List<Product>>();
            try
            {
                result.RequestData = await _reportStorage.GetSoldOutProduct();
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
