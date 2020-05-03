using System;
using System.Threading.Tasks;
using WebStore.DB.Models;
using WebStore.DB.Storages;
using WebStore.Repository.Common;

namespace WebStore.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderStorage _orderStorage;

        public OrderRepository(IOrderStorage orderStorage)
        {
            _orderStorage = orderStorage;
        }

        public async ValueTask<RequestResult<OrderInfo>> OrderGetById(int productId)
        {
            var result = new RequestResult<OrderInfo>();
            try
            {
                result.RequestData = await _orderStorage.OrderGetById(productId);

                decimal currencyExchangeRate;
                string valute;
                switch (result.RequestData.Store.City.Name)
                {
                    case "Минск":
                        valute = "BYN";
                        currencyExchangeRate = await GetCurrencyExchangeRate.GetCurrency(valute);
                        break;
                    case "Киев":
                        valute = "UAH";
                        currencyExchangeRate = await GetCurrencyExchangeRate.GetCurrency(valute);
                        break;
                    default:
                        currencyExchangeRate = 1;
                        break;
                }

                result.RequestData.Total = Math.Round(result.RequestData.Total / currencyExchangeRate);
                result.RequestData.Product.Price = Math.Round(result.RequestData.Product.Price / currencyExchangeRate);

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
