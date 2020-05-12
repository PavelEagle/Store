using WebStore.DB.Models;
using WebStore.DB.Models.Reports;
using WebStore.DB.Storages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Core;

namespace WebStore.Repository.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IReportStorage _reportStorage;

        public ReportRepository(IReportStorage reportStorage)
        {
            _reportStorage = reportStorage;
        }

        public async ValueTask<RequestResult<List<City>>> GetMoneyInEachCity()
        {
            var result = new RequestResult<List<City>>();
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

        public async ValueTask<RequestResult<List<ProductInStore>>> GetBestSellingProducts()
        {
            var result = new RequestResult<List<ProductInStore>>();
            try
            {
                result.RequestData = await _reportStorage.GetBestSellingProducts();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<ProductInStore>>> GetProductsInWarehouseAndAbsentInMskAndSpb()
        {
            var result = new RequestResult<List<ProductInStore>>();
            try
            {
                result.RequestData = await _reportStorage.GetProductsInWarehouseAndAbsentInMskAndSpb();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Category>>> GetCategoryWithFiveAndMoreProducts()
        {
            var result = new RequestResult<List<Category>>();
            try
            {
                result.RequestData = await _reportStorage.GetCategoryWithFiveAndMoreProducts();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<OrderInfo>>> GetInfoAboutOrdersByDate(string startDate, string endDate)
        {
            var result = new RequestResult<List<OrderInfo>>();
            try
            {
                result.RequestData = await _reportStorage.GetInfoAboutOrdersByDate(startDate, endDate);
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

        public async ValueTask<RequestResult<SalesByWorldAndRF>> GetSalesByWorldAndRF()
        {
            var result = new RequestResult<SalesByWorldAndRF>();
            try
            {
                result.RequestData = await _reportStorage.GetSalesByWorldAndRF();
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
