using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace WebStore.Repository.Common
{
    public static class GetCurrencyExchangeRate
    {
        public static async ValueTask<decimal> GetCurrency(string valute)
        {
            string url = "https://www.cbr-xml-daily.ru/daily_json.js";
            WebRequest request = WebRequest.CreateHttp(url);
            Stream dataStream;
            WebResponse response = await request.GetResponseAsync();
            string result;
            using (dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();
            }
            response.Close();
            JObject jsonObj = JsonConvert.DeserializeObject<JObject>(result);
            var currencyExchangeRate = (decimal)jsonObj.SelectToken($"$.Valute.{valute}.Value");

            return currencyExchangeRate;
        }
    }
}
