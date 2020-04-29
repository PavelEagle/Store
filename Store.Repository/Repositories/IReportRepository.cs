using Store.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Repository
{
    public interface IReportRepository
    {
        ValueTask<RequestResult<List<MoneyInCity>>> ProductGetById();
    }
}