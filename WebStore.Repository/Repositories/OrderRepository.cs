using System;
using System.Threading.Tasks;
using WebStore.Core;
using WebStore.DB.Models;
using WebStore.DB.Storages;

namespace WebStore.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderStorage _orderStorage;

        public OrderRepository(IOrderStorage orderStorage)
        {
            _orderStorage = orderStorage;
        }

        public async ValueTask<RequestResult<OrderInfo>> OrderGetById(int orderId)
        {
            var result = new RequestResult<OrderInfo>();
            try
            {
                result.RequestData = await _orderStorage.OrderGetById(orderId);

                decimal currencyExchangeRate;
                switch (result.RequestData.Store.City.Id)
                {
                    case (int)CityEnum.Minsk:
                        currencyExchangeRate = CurrencyRates.ActualCurrencyRates.Find(item => item.Code == "BYN").Rate;
                        break;
                    case (int)CityEnum.Kiev:
                        currencyExchangeRate = CurrencyRates.ActualCurrencyRates.Find(item => item.Code == "UAH").Rate;
                        break;
                    default:
                        currencyExchangeRate = 1;
                        break;
                }

                //result.RequestData.Total = Math.Round(result.RequestData.Total / currencyExchangeRate);
                //result.RequestData.Product.Price = Math.Round(result.RequestData.Product.Price / currencyExchangeRate);

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
