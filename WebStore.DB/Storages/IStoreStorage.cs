using WebStore.DB.Models;
using System.Threading.Tasks;

namespace WebStore.DB.Storages
{
    public interface IStoreStorage
    {
        ValueTask<City> CityInsert(City model);
    }
}