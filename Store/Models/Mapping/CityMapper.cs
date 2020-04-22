using Store.API.Models.InputModels;
using Store.API.Models.OutputModels;
using Store.DB.Models;
using System.Collections.Generic;

namespace Store.API.Models.Mapping
{
    public class CityMapper
    {
		public static List<CityOutputModel> cityOutputModels(List<City> cities)
		{
			List<CityOutputModel> result = new List<CityOutputModel>();
			foreach (City city in cities)
			{
				result.Add(ToOutputModel(city));
			}
			return result;
		}

		public static CityOutputModel ToOutputModel(City city)
		{
			return new CityOutputModel
			{
				Id = (int)city.Id,
				Name = city.Name,
				RU = city.RU
			};
		}

		public static City ToDataModel(CityInputModel city)
		{
			return new City
			{
				Name = city.Name,
				RU = city.RU
			};
		}
	}
}
