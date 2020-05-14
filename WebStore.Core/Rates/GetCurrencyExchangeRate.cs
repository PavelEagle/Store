using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;

namespace WebStore.Core
{
    public static class GetCurrencyExchangeRate
    {
        public static void GetRates()
        {
            List<Currency> currencies = new List<Currency>();

            var client = new RestClient("https://www.cbr-xml-daily.ru");
            var request = new RestRequest("daily_json.js", Method.GET);
            var response = client.Execute(request);
            JObject jsonObj = JObject.Parse(response.Content);

            foreach (var item in Enum.GetValues(typeof(CurrencyEnum)))
            {
                decimal rate;
                if (jsonObj.SelectToken($"$.Valute.{item}.Value") != null)
                    rate = (decimal)jsonObj.SelectToken($"$.Valute.{item}.Value");
                else
                    rate = 1;
                Currency currency = new Currency()
                {
                    Code = item.ToString(),
                    Rate = rate
                };
                currencies.Add(currency);
            }
            CurrencyRates.ActualCurrencyRates = currencies;
        }
    }
}
