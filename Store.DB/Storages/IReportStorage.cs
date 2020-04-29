using Store.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DB.Storages
{
    public interface IReportStorage
    {
        ValueTask<List<MoneyInCity>> GetMoneyInEachCity();
    }
}