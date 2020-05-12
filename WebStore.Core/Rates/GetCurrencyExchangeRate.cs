using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Timers;

namespace WebStore.Core
{
    public static class GetCurrencyExchangeRate
    {
        public static void GetRates()
        {
            List<Currency> currencies = new List<Currency>();
            WebRequest request = WebRequest.CreateHttp("https://www.cbr-xml-daily.ru/daily_json.js");
            WebResponse response = request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string result = reader.ReadToEnd();
                JObject jsonObj = JObject.Parse(result);
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
            }
            CurrencyRates.ActualCurrencyRates = currencies;
        }
    }
}
